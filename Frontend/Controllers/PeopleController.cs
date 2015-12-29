using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using ScalabiltyHomework.Data;

namespace ScalabiltyHomework.Frontend.Controllers
{
    public class PeopleController : Controller
    {
        public async Task<ActionResult> Index()
        {
            using (var db = new HeroesContext())
            {
                return View(await Task.Run(() => db.People.ToList()));
            }
        }
    }
}
