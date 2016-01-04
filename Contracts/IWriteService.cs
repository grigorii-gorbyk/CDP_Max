using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScalabiltyHomework.Contracts.Entities;
using ScalabiltyHomework.Contracts.ReadModels;

namespace ScalabiltyHomework.Contracts
{
    public interface IWriteService : IDisposable
    {
        //People

        //Hero
        void CreateHero(Hero hero);
    }
}
