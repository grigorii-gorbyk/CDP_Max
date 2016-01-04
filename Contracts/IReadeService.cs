using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScalabiltyHomework.Contracts.Entities;
using ScalabiltyHomework.Contracts.ReadModels;

namespace ScalabiltyHomework.Contracts
{
    public interface IReadService : IDisposable
    {
        //People
        IEnumerable<Person> GetAllPeople();
        Person Find(params object[] keyValues);

        //Hero
        IEnumerable<Hero> GetLastHeroes();
        IEnumerable<HeroView> GetTopHeroes();        
    }
}
