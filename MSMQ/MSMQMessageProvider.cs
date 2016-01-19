using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Queuing;
using Contracts.Queuing.Messages;
using System.Messaging;
using MSMQ.Handlers;

namespace MSMQ
{
    public class MSMQMessageProvider : IMessageProvider
    {
        #region static part

        private static MSMQMessageProvider _provider;

        public static MSMQMessageProvider GetProvider()
        {
            if (_provider == null)
            {
                _provider = new MSMQMessageProvider();

                _provider.Register(typeof(AddHeroMessage).FullName, new AddHeroMessageHandler(_provider));
                _provider.Register(typeof(AddHeroReadMessage).FullName, new AddHeroReadMessageHandler(_provider));
            }

            return _provider;
        }

        #endregion


        internal Dictionary<string, IMSMQMessageHandler> handlers = new Dictionary<string, IMSMQMessageHandler>();

        public void Register<T>(string messageTypeName, IMSMQMessageHandler<T> handler) where T : IMessage
        {
            handlers.Add(typeof(T).FullName, handler);
        }

        #region IMessageProvider implementation

        public void Send<T>(T message) where T : IMessage
        {
            var handler = GetHandler<T>();

            using (MessageQueue queue = GetQueue(handler.QueuePath))
            {
                Message msg = new Message();
                msg.Body = message;
                msg.Label = DateTime.Now.ToLongDateString();
                queue.Send(msg);
            }
            //fake message handling
#if DEBUG
            HandleMessages<T>();
#endif
        }

        public void HandleMessages<T>() where T : IMessage
        {
            var handler = GetHandler<T>();

            using (var queue = GetQueue(handler.QueuePath))
            {
                //var message = _queue.Receive(new TimeSpan(0, 0, 1));

                var enumerator = queue.GetMessageEnumerator2();
                while (enumerator.MoveNext())
                {
                    var msg = queue.ReceiveById(enumerator.Current.Id);
                    msg.Formatter = new XmlMessageFormatter(new Type[] { typeof(T) });
                    handler.Handle((T)(msg.Body));
                }

                //var messages = queue.GetAllMessages();
                //foreach (var msg in messages)
                //{                    
                //    msg.Formatter = new XmlMessageFormatter(new Type[] { typeof(T) });
                //    handler.Handle((T)(msg.Body));
                //}                
                
            }
        }

        #endregion

        private MessageQueue GetQueue(string path)
        {
            return
                MessageQueue.Exists(path) ? new MessageQueue(path) : MessageQueue.Create(path, false);
        }

        private IMSMQMessageHandler<T> GetHandler<T>() where T : IMessage
        {
            var handler = (IMSMQMessageHandler<T>)handlers[typeof(T).FullName];
            return handler;
        }
    }
}
