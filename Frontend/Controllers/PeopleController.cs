using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using Polly;
using ScalabiltyHomework.Data;

namespace ScalabiltyHomework.Frontend.Controllers
{
    [HandleError(View = "Error")]
    public class PeopleController : Controller
    {
        public ActionResult Index()
        {
            var dalPolicy = Policy.Handle<DbException>().Retry(3);

            using (var db = new HeroesContext())
            {
                return View(dalPolicy.Execute(() => db.People.ToList()));
            }
        }
    }
}
