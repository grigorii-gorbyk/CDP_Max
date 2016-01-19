using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Queuing;

namespace MSMQ.Handlers
{
    public interface IMSMQMessageHandler { }

    public interface IMSMQMessageHandler<T> : IMSMQMessageHandler where T : IMessage
    {
        IMessageProvider MessageProvider { get; }
        string QueuePath { get; }
        void Handle(T message);
    }
}
