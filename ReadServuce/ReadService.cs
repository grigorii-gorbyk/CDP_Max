using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScalabiltyHomework.Contracts;
using ScalabiltyHomework.Contracts.Entities;
using ScalabiltyHomework.Contracts.ReadModels;
using ScalabiltyHomework.Data;
using System.Data.Entity;
using ScalabiltyHomework.Contracts.Entities.Read;

namespace ScalabiltyHomework.Services
{
    public class ReadService : IReadService, IDisposable
    {
        private HeroesReadContext _dbRead = new HeroesReadContext();

        public IEnumerable<PersonRead> GetAllPeople()
        {
            return _dbRead.Persons.ToList();
        }

        public PersonRead Find(params object[] keyValues)
        {
            return _dbRead.Persons.Find(keyValues);
        }

        public IEnumerable<LatestHero> GetLastHeroes()
        {
            return _dbRead.LatestHeroes
                .OrderByDescending(lh => lh.Id)
                .ToList();
        }

        public PersonRead FindById(int writeId)
        {
            return _dbRead.Persons.FirstOrDefault(pr=>pr.WriteId == writeId);
        }

        public IEnumerable<PersonPromotionsCount> GetTopHeroes()
        {
            return _dbRead.Promotions.OrderByDescending(p => p.Count).Take(100).ToList();
        }
        
        public void Dispose()
        {
            //_db.Dispose();
        }

        #region
        //private HeroesContext _db = new HeroesContext();

        //public IEnumerable<Person> GetAllPeople()
        //{
        //    return _db.People.ToList();
        //}

        //public Person Find(params object[] keyValues)
        //{
        //    return _db.People.Find(keyValues);
        //}

        //public IEnumerable<Hero> GetLastHeroes()
        //{
        //    //return _db.Heroes.Include(h => h.Person).ToList();
        //    return _db.Heroes.Include(h => h.Person).ToList();
        //}

        //public IEnumerable<HeroView> GetTopHeroes()
        //{
        //    var heroes = _db.Heroes.Include(h => h.Person);
        //    var grouppedHeroes = heroes.GroupBy(h => h.Person.Id);
        //    var views = new List<HeroView>();
        //    foreach (var group in grouppedHeroes)
        //    {
        //        var view = new HeroView(group.FirstOrDefault(), group.Count());
        //        views.Add(view);
        //    };
        //    return views;
        //}
        #endregion       
    

      
    }
}
