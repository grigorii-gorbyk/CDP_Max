using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ScalabiltyHomework.Data;
using ScalabiltyHomework.Contracts;
using ScalabiltyHomework.Contracts.Entities;
using ScalabiltyHomework.Contracts.ReadModels;

namespace ScalabiltyHomework.Frontend.Controllers
{
    public class HeroesController : Controller
    {
        //private HeroesContext _db = new HeroesContext();
        private IReadService _readService;
        private IWriteService _writeService;


        public HeroesController()
        {
            //TODO: USE DI            
            _readService = new ScalabiltyHomework.Services.ReadService();
            _writeService = new ScalabiltyHomework.Services.WriteService();
        }

        public ActionResult Index()
        {

            //var heroes = _db.Heroes.Include(h => h.Person);
            //return View(heroes.ToList());
            return View(_readService.GetLastHeroes());
        }

        public ActionResult Latest()
       { 
            //var heroes = _db.Heroes.Include(h => h.Person);
            //return View(heroes.ToList());
            return View(_readService.GetLastHeroes());
        }

        public ActionResult Top()
        {
            //var heroes = _db.Heroes.Include(h => h.Person);
            //var grouppedHeroes = heroes.GroupBy(h => h.Person.Id);
            //var views = new List<HeroView>();
            //foreach (var group in grouppedHeroes)
            //{
            //    var view = new HeroView(group.FirstOrDefault(), group.Count());
            //    views.Add(view);
            //};

            return View(_readService.GetTopHeroes());
        }

        public ActionResult Promote(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //var person = _db.People.Find(id.Value);            
            var person = _readService.Find(id.Value);
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
                //_db.Heroes.Add(hero);
                //_db.SaveChanges();
                _writeService.CreateHero(hero);

                // Don't do like this. Create separate messaging service to handle messages and errors collections
                TempData["Messages"] = new List<string>() { "Congrats! Your hero was promoted." };

                return RedirectToAction("Index", "People");
            }

            //var person = db.People.Find(hero.PersonId);
            return View(hero);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //_db.Dispose();
                _readService.Dispose();
                _writeService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
