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
    public static class FakeMessagesHandler
    {
        static MessageQueue _queue = new MessageQueue(@".\Private$\CreateHero");

        public static void HandleHeroMessage()
        {
            try
            {
                //var message = _queue.Receive(new TimeSpan(0, 0, 1));
                var messages = _queue.GetAllMessages();
                using (var db = new HeroesContext())
                {
                    foreach (var message in messages)
                    {
                        message.Formatter = new XmlMessageFormatter(new Type[] { typeof(Hero) });
                        var hero = (Hero)(message.Body);


                        db.Heroes.Add(hero);
                        db.SaveChanges();
                    }
                }                
            }
            catch
            {

            }
        }
    }
}
