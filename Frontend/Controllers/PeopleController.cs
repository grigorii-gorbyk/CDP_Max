using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using ScalabiltyHomework.Data;
using ScalabiltyHomework.Data.Entity;

namespace ScalabiltyHomework.Frontend.Controllers
{
    public class PeopleController : Controller
    {
        public ActionResult Index()
        {
            using (var db = new HeroesReadContext())
            {
                var persons = db.Persons.ToList();
                return View(persons);
            }
        }
    }
}
