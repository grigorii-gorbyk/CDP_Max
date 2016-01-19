using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Queuing;
using Contracts.Queuing.Messages;
using MSMQ;
using ScalabiltyHomework.Data;
using ScalabiltyHomework.Contracts.Entities;

namespace MSMQ.Handlers
{
    public class AddHeroMessageHandler : IMSMQMessageHandler<AddHeroMessage>
    {
        public AddHeroMessageHandler(IMessageProvider provider)
        {
            MessageProvider = provider;
        }

        public IMessageProvider MessageProvider { get; private set; }

        public string QueuePath
        {
            get { return @".\Private$\read_CreateHero"; }
        }

        public void Handle(AddHeroMessage message)
        {
            using (var db = new HeroesContext())
            {
                var hero = message.Hero;
                var addedHero = db.Heroes.Add(hero);
                db.SaveChanges();
                // send messages for read context
                CreateHeroForReadContext(addedHero);
            }
        }

        private void CreateHeroForReadContext(Hero hero)
        {
            try
            {
                var message = new AddHeroReadMessage() { Hero = hero };
                MessageProvider.Send(message);
            }
            catch
            {

            }            
        }
    }
}
