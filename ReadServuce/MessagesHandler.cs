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
        static string _wCreateHeroPath = @".\Private$\CreateHero";
        static string _rCreateHeroPath = @".\Private$\readCreateHero";
        //static MessageQueue Read_CreateHeroQueue = new MessageQueue(@".\Private$\Read_CreateHero");

        public static void HandleMessages()
        {
            HandleCreateHeroMessages();

        }

        private static void HandleCreateHeroMessages()
        {

            using (var createWriteHeroQueue = GetQueue(_wCreateHeroPath))
            {
                //var messages = createWriteHeroQueue.Receive(new TimeSpan(1, 0, 0));// .GetAllMessages();
                using (var db = new HeroesContext())
                {
                    foreach (var message in createWriteHeroQueue.GetAllMessages())
                    {
                        message.Formatter = new XmlMessageFormatter(new Type[] { typeof(Hero) });
                        var hero = (Hero)(message.Body);
                        db.Heroes.Add(hero);
                        db.SaveChanges();

                        // delete the message                        
                        // send messages for read context
                        CreateHeroForReadContext(hero);
                    }
                }
            }
        }

        private static void CreateHeroForReadContext(Hero hero)
        {
            using (var queue = GetQueue(_rCreateHeroPath))
            {
                //Message handlers
            }
        }

        private static MessageQueue GetQueue(string path)
        {
            return
                MessageQueue.Exists(path) ? new MessageQueue(path) : MessageQueue.Create(path);
        }
    }
}
