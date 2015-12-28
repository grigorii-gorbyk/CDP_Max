using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ScalabiltyHomework.Data;
using ScalabiltyHomework.Data.Entity;
using ScalabiltyHomework.Frontend.Controllers.ViewModels;
using AutoMapper;
using System;

namespace ScalabiltyHomework.Frontend.Controllers
{
    public class HeroesController : Controller
    {
        private HeroesContext _db = new HeroesContext();
        private HeroesReadContext _dbRead = new HeroesReadContext();        

        public ActionResult Index()
        {
            //var heroes = _db.Heroes.Include(h => h.Person);
            return View(_dbRead.LatestHeroes.ToList());
        } 

        public ActionResult Latest()
        {
            //var heroes = _db.Heroes.Include(h => h.Person);
            var heroes = _dbRead.LatestHeroes.ToList();
            return View(heroes);
        }

        public ActionResult Top()
        { 
            var heroes = _db.Heroes.Include(h => h.Person);
            var grouppedHeroes = heroes.GroupBy(h => h.Person.Id);
            var views = new List<HeroView>();
            foreach (var group in grouppedHeroes)
            {
                var view = new HeroView(group.FirstOrDefault(), group.Count());
                views.Add(view);
            };

            return View(views);
        }

        public ActionResult Promote(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var person = _db.People.Find(id.Value);
            if (person == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(new Hero(person, ""));
        }

        // GET: Heroes/MakeHero/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Promote([Bind(Include = "PersonId,Comment")] Hero hero)
        {
            if (ModelState.IsValid)
            {
                var writeHero = _db.Heroes.Add(hero);
                _db.SaveChanges();

                AddHeroToReadContext(writeHero);

                // Don't do like this. Create separate messaging service to handle messages and errors collections
                TempData["Messages"] = new List<string>() { "Congrats! Your hero was promoted." };

                return RedirectToAction("Index", "People");
            }
            
            return View(hero);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
        
        private void AddHeroToReadContext(Hero hero)
        {
            if (hero == null) return;

            var readHero = _dbRead.Heroes.Add(Mapper.Map<Hero, HeroRead>(hero));

            var readPerson = _dbRead.Persons.Find(hero.PersonId);
            if (readPerson == null) throw new InvalidOperationException();

            _dbRead.LatestHeroes.Add(new LatestHero(readPerson, readHero));

            _dbRead.SaveChanges();
        }
    }
}
