using System.Linq;
using System.Web.Mvc;
using ScalabiltyHomework.Data;

namespace ScalabiltyHomework.Frontend.Controllers
{
    public class PeopleController : Controller
    {
        public ActionResult Index()
        {
            using (var db = new HeroesContext())
            {
                return View(db.People.ToList());
            }
        }
    }
}
