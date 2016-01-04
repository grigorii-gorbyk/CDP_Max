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
using System.Messaging;

namespace ScalabiltyHomework.Services
{
    public class WriteEFService : IWriteService
    {
        private HeroesContext _db = new HeroesContext();
        
        public void CreateHero(Hero hero)
        {
            _db.Heroes.Add(hero);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
