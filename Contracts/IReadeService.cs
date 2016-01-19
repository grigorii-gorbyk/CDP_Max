using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScalabiltyHomework.Contracts.Entities;
using ScalabiltyHomework.Contracts.ReadModels;
using ScalabiltyHomework.Contracts.Entities.Read;

namespace ScalabiltyHomework.Contracts
{
    //public interface IReadService : IDisposable
    //{
    //    //People
    //    IEnumerable<Person> GetAllPeople();
    //    Person Find(params object[] keyValues);

    //    //Hero
    //    IEnumerable<Hero> GetLastHeroes();
    //    IEnumerable<HeroView> GetTopHeroes();        
    //}

    public interface IReadService : IDisposable
    {
        //People
        IEnumerable<PersonRead> GetAllPeople();
        PersonRead Find(params object[] keyValues);

        /// <summary>
        /// Finds by Write context Id (this is original id)
        /// </summary>
        /// <param name="writeId"></param>
        /// <returns></returns>
        PersonRead FindById(int writeId);

        //Hero
        IEnumerable<LatestHero> GetLastHeroes();
        IEnumerable<PersonPromotionsCount> GetTopHeroes();
    }    
}
