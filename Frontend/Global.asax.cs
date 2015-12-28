using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Frontend;
using ScalabiltyHomework.Data;

namespace ScalabiltyHomework.Frontend
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            MapperConfig.Register();

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<HeroesContext, Data.Migrations.Configuration>());
        }
    }
}
