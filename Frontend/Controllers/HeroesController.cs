using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using ScalabiltyHomework.Data;
using ScalabiltyHomework.Data.Entity;
using ScalabiltyHomework.Frontend.Controllers.ViewModels;

namespace ScalabiltyHomework.Frontend.Controllers
{
    public class HeroesController : Controller
    {
        private HeroesContext _db = new HeroesContext();

        public async Task<ActionResult> Index()
        {
            var heroes = await Task.Run(() => _db.Heroes.Include(h => h.Person));
            return View(heroes);
        }

        public async Task<ActionResult> Latest()
        {
            var heroes = await Task.Run(() => _db.Heroes.Include(h => h.Person).OrderByDescending(h => h.Id).Take(100).ToList());
            return View(heroes);
        }

        public async Task<ActionResult> Top()
        {
            // accept that there aretoo many  heroes  and grouping is time consuming
            // so put everyting into task

            // TODO possible group by LINQ JOINs
            var viewsFromTask = await Task.Run(() =>
            {
                var heroes = _db.Heroes.Include(h => h.Person);
                var grouppedHeroes = heroes.GroupBy(h => h.Person.Id);
                var views = new List<HeroView>();
                foreach (var group in grouppedHeroes)
                {
                    var view = new HeroView(group.FirstOrDefault(), group.Count());
                    views.Add(view);
                }
                return views;
            });
            return View(viewsFromTask);
        }

        public async Task<ActionResult> Promote(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var person = await Task.Run(() => _db.People.Find(id.Value));

            if (person == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(new Hero(person, ""));
        }

        // GET: Heroes/MakeHero/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Promote([Bind(Include = "PersonId,Comment")] Hero hero)
        {
            if (ModelState.IsValid)
            {
                await Task.Run(() =>
                {
                    _db.Heroes.Add(hero);
                    _db.SaveChanges();
                });

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
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
