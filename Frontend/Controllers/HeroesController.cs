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
using System.Data.Entity.Migrations;

namespace ScalabiltyHomework.Frontend.Controllers
{
    public class HeroesController : Controller
    {
        private HeroesContext _db = new HeroesContext();
        private HeroesReadContext _dbRead = new HeroesReadContext();
        
        public ActionResult Index()
        {
            return View(_dbRead.LatestHeroes.ToList());
        } 

        public ActionResult Latest()
        {
            var heroes = _dbRead.LatestHeroes.OrderByDescending(h => h.Id).Take(100).ToList();
            return View(heroes);
        }

        public ActionResult Top()
        {
            var views =
                Mapper.Map<IList<HeroView>>(
                    _dbRead.Promotions.OrderByDescending(p => p.Count).Take(100).ToList());

            return View(views);
        }

        public ActionResult Promote(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var person = _dbRead.Persons.FirstOrDefault(p => p.WriteId == id.Value);
            if (person == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(new HeroRead(person, ""));
        }

        // GET: Heroes/MakeHero/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Promote([Bind(Include = "PersonId,PersonWriteId,Comment")] HeroRead readHero)
        {
            if (ModelState.IsValid)
            {
                var writeHero = _db.Heroes.Add(Mapper.Map<HeroRead, Hero>(readHero));
                _db.SaveChanges();

                AddPromotionToReadContext(readHero);
                // Don't do like this. Create separate messaging service to handle messages and errors collections
                TempData["Messages"] = new List<string>() { "Congrats! Your readHero was promoted." };

                return RedirectToAction("Index", "People");
            }

            return View(Mapper.Map<HeroRead>(readHero));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
        
        private void AddPromotionToReadContext(HeroRead readHero)
        {
            if (readHero == null) return;

            //var readHero = _dbRead.Heroes.Add(Mapper.Map<Hero, HeroRead>(readHero));

            var readPerson = _dbRead.Persons.Find(readHero.PersonId);
            if (readPerson == null) throw new InvalidOperationException();
            
            //Latest view
            _dbRead.LatestHeroes.Add(new LatestHero(readPerson, readHero));
            
            //Top promotions view
            var promotionsData = _dbRead.Promotions.FirstOrDefault(p => p.PersonId == readPerson.Id);
            if (promotionsData == null)
            {
                _dbRead.Promotions.Add(new PersonPromotionsCount(readPerson));
            }
            else
            {
                promotionsData.Count++;
            }

            _dbRead.SaveChanges();
        }
    }
}
