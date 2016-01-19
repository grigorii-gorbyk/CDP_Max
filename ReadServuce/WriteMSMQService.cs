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
    public class WriteService : IWriteService
    {
        //private HeroesContext _db = new HeroesContext();
        MessageQueue _queue = new MessageQueue(@".\Private$\CreateHero");

        public void CreateHero(Hero hero)
        {
            // send Message                        
            Message msg = new Message();
            msg.Body = hero;
            msg.Label = "some test label";
            _queue.Send(msg);

            // INFO: used instead of retrieving and processing by some remote process.
            Task.Run(() => FakeMessagesHandler.HandleHeroMessage());
        }

        public void Dispose()
        {            
            _queue.Close();
        }
    }
}
