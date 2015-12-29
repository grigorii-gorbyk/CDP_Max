using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Glav.CacheAdapter.Core;
using Glav.CacheAdapter.Core.DependencyInjection;
using ScalabiltyHomework.Data;
using ScalabiltyHomework.Data.Entity;
using ScalabiltyHomework.Frontend.Caching;

namespace ScalabiltyHomework.Frontend.Controllers
{
    public class PeopleController : Controller
    {
        private ICacheProvider _cacheProvider;

        public PeopleController()
        {
            _cacheProvider = AppServices.Cache;
        }

        public ActionResult Index()
        {
            using (var db = new HeroesContext())
            {
                // here cache may be infinite time because we do not add new people
                // if add new people then must apply _cacheProvider.InvalidateCacheItem
                var people = _cacheProvider.Get<IList<Person>>(CacheKey.AllPeople, DateTime.Now.AddDays(1), () =>
                {
                    return db.People.ToList();
                });

                return View(people);
            }
        }
    }
}
