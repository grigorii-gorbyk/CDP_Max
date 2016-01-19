using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Queuing;
using Contracts.Queuing.Messages;
using MSMQ;
using ScalabiltyHomework.Data;
using ScalabiltyHomework.Contracts.Entities.Read;


namespace MSMQ.Handlers
{
    public class AddHeroReadMessageHandler : IMSMQMessageHandler<AddHeroReadMessage>
    {
        public AddHeroReadMessageHandler(IMessageProvider provider)
        {
            MessageProvider = provider;
        }

        public IMessageProvider MessageProvider { get; private set; }

        public string QueuePath
        {
            get { return @".\Private$\CreateHero"; }
        }

        public void Handle(AddHeroReadMessage message)
        {
            using (var _dbRead = new HeroesReadContext())
            {
                var hero = message.Hero;
                // HeroRead
                var readPerson = _dbRead.Persons.FirstOrDefault(pr => pr.WriteId == hero.PersonId);
                if (readPerson == null) throw new InvalidOperationException();

                var readHero = _dbRead.Heroes.Add(new HeroRead
                {
                    Person = readPerson,
                    Comment = hero.Comment,
                    PersonId = readPerson.Id,
                    PersonWriteId = readPerson.WriteId,
                    PromotionDate = hero.PromotionDate
                });

                //Latest view
                _dbRead.LatestHeroes.Add(new LatestHero(readPerson, readHero));

                //Top promotions view
                var promotionsData = _dbRead.Promotions.FirstOrDefault(p => p.PersonId == readPerson.Id);
                if (promotionsData == null)
                {
                    _dbRead.Promotions.Add(new PersonPromotionsCount(readPerson));
                }
                else
                {
                    promotionsData.Count++;
                }

                _dbRead.SaveChanges();
            }
        }        
    }
}
