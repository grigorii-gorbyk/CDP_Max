using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Queuing
{    
    public interface IMessageProvider
    {
        //void Register<M, T>() where M : IMessageMetadata<T>;
        void Send<T>(T message) where T : IMessage;
        void HandleMessages<T>() where T : IMessage;
    }
}
