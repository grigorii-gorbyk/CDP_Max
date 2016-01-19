using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScalabiltyHomework.Contracts;
using Contracts.Queuing;
using Contracts.Queuing.Messages;
using ScalabiltyHomework.Contracts.Entities;
using ScalabiltyHomework.Contracts.ReadModels;
using ScalabiltyHomework.Data;
using System.Data.Entity;
using System.Messaging;

namespace ScalabiltyHomework.Services
{
    public class WriteService : IWriteService
    {
        private readonly IMessageProvider _messageQueueProvider;

        public WriteService()
        {
            _messageQueueProvider = MSMQ.MSMQMessageProvider.GetProvider();
        }

        public WriteService(IMessageProvider messageQueueProvider)
        {
            _messageQueueProvider = messageQueueProvider;
        }

        //private HeroesContext _db = new HeroesContext();
        //MessageQueue _queue = new MessageQueue(@".\Private$\CreateHero");

        //public void CreateHero(Hero hero)
        //{
        //    // send Message                        
        //    Message msg = new Message();
        //    msg.Body = hero;
        //    msg.Label = "some test label";
        //    _queue.Send(msg);

        //    // INFO: used instead of retrieving and processing by some remote process.
        //    Task.Run(() => FakeMessagesHandler.HandleMessages());
        //}

        public void CreateHero(Hero hero)
        {
            var addHeroMessage = new AddHeroMessage()
            {
                Hero = hero
            };

            _messageQueueProvider.Send(addHeroMessage);

            //// send Message                        
            //Message msg = new Message();
            //msg.Body = hero;
            //msg.Label = "some test label";
            //_queue.Send(msg);

            //// INFO: used instead of retrieving and processing by some remote process.
            //Task.Run(() => FakeMessagesHandler.HandleMessages());
        }

        public void Dispose()
        {
            //_queue.Close();
        }
    }
}
