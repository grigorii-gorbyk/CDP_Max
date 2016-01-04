using System;
using System.Linq;
using System.Web.Mvc;
using ScalabiltyHomework.Data;
using ScalabiltyHomework.Contracts;
using ScalabiltyHomework.Contracts.Entities;

namespace ScalabiltyHomework.Frontend.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IReadService _readService;

        public PeopleController()
        {
            //TODO: USE DI            
            _readService = new ScalabiltyHomework.Services.ReadService();
        }

        public ActionResult Index()
        {
            using (var db = new HeroesContext())
            {
                //db.People.Add(new Person(){
                //    Name = Guid.NewGuid().ToString(),
                //    Gender= Gender.Woman
                //});
                //db.SaveChanges();

                //return View(db.People.ToList());
                return View(_readService.GetAllPeople());
            }
        }
    }
}
