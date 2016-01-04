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

namespace ScalabiltyHomework.Services
{
    public class ReadService : IReadService, IDisposable
    {

        private HeroesContext _db = new HeroesContext();
        
        public IEnumerable<Person> GetAllPeople()
        {
            //throw new NotImplementedException();
            //using (var db = new ScalabiltyHomework.Data.HeroesContext())
            //{
            //    //db.People.Add(new Person(){
            //    //    Name = Guid.NewGuid().ToString(),
            //    //    Gender= Gender.Woman
            //    //});
            //    //db.SaveChanges();                
            //}

            return _db.People.ToList();
        }


        public Person Find(params object[] keyValues)
        {
            return _db.People.Find(keyValues);
        }

        public IEnumerable<Hero> GetLastHeroes()
        {
            //return _db.Heroes.Include(h => h.Person).ToList();
            return _db.Heroes.Include(h => h.Person).ToList();
        }

        public IEnumerable<HeroView> GetTopHeroes()
        {
            var heroes = _db.Heroes.Include(h => h.Person);
            var grouppedHeroes = heroes.GroupBy(h => h.Person.Id);
            var views = new List<HeroView>();
            foreach (var group in grouppedHeroes)
            {
                var view = new  HeroView(group.FirstOrDefault(), group.Count());
                views.Add(view);
            };
            return views;
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
