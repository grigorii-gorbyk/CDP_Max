using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScalabiltyHomework.Data;

namespace Frontend.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var db = new HeroesContext())
            {
                var herosCount = db.Heroes.Count();
                if (herosCount > 0)
                {
                    return RedirectToAction("Top", "Heroes");
                }
                else
                {
                    return RedirectToAction("Index", "People");
                }
            }
        }
    }
}