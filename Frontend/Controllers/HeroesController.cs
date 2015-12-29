using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Polly;
using ScalabiltyHomework.Data;
using ScalabiltyHomework.Data.Entity;
using ScalabiltyHomework.Frontend.Controllers.ViewModels;

namespace ScalabiltyHomework.Frontend.Controllers
{
    public class HeroesController : Controller
    {
        private Policy _dalPolicy, _controllerPolicy, _viewRenderPolicy;
        private HeroesContext _db;

        public HeroesController()
        {
            _dalPolicy = Policy.Handle<DbException>().Retry(3);
            _controllerPolicy = Policy.Handle<InvalidOperationException>().Retry();
            _viewRenderPolicy = Policy.Handle<ViewRenderingException>().Retry();

            _db = new HeroesContext();
        }
        
        public ActionResult Index()
        {
            //try
            //{

            var heroes = _dalPolicy.Execute(() => _db.Heroes.Include(h => h.Person).ToList());

            return _viewRenderPolicy.Execute(() => View(heroes));
            //}
            //catch
            //{
            //    return View("Error");
            //}
        }

        public ActionResult Latest()
        {
            //try
            //{
            //throw new ViewRenderingException();
            var heroes = _dalPolicy.Execute(() =>
            {
                return _db.Heroes.Include(h => h.Person).ToList();
            });
            return _viewRenderPolicy.Execute(() => View(heroes));
            //}
            //catch
            //{
            //    return View("Error");
            //}
        }

        public ActionResult LatestDalError()
        {
            var attemptsCount = 0;
            try
            {
                var heroes = _dalPolicy.Execute(() =>
                {
                    attemptsCount++;
                    throw new CustomDbException();
                    return _db.Heroes.Include(h => h.Person).ToList();
                });
                return _viewRenderPolicy.Execute(() => View(heroes));
            }
            catch
            {
                return View("ErrorWithAttempts", attemptsCount);
            }
        }

        public ActionResult Top()
        {
            var heroes = _dalPolicy.Execute(() => _db.Heroes.Include(h => h.Person).ToList());

            var viewData = _controllerPolicy.Execute(() =>
            {
                var views = new List<HeroView>();
                var grouppedHeroes = heroes.GroupBy(h => h.Person.Id);
                foreach (var group in grouppedHeroes)
                {
                    var view = new HeroView(group.FirstOrDefault(), group.Count());
                    views.Add(view);
                }
                return views;
            });

            return _viewRenderPolicy.Execute(() => View(viewData));
        }

        public ActionResult Promote(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var person = _dalPolicy.Execute(() => _db.People.Find(id.Value));

            if (person == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return _viewRenderPolicy.Execute(() => View(new Hero(person, "")));
        }

        // GET: Heroes/MakeHero/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Promote([Bind(Include = "PersonId,Comment")] Hero hero)
        {
            if (ModelState.IsValid)
            {
                _dalPolicy.Execute(() =>
                {
                    _db.Heroes.Add(hero);
                    _db.SaveChanges();
                });

                _controllerPolicy.Execute(() =>
                {
                    // Don't do like this. Create separate messaging service to handle messages and errors collections
                    TempData["Messages"] = new List<string>() {"Congrats! Your hero was promoted."};
                });

                return RedirectToAction("Index", "People");
            }

            //var person = db.People.Find(hero.PersonId);
            return _viewRenderPolicy.Execute(() => View(hero));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
