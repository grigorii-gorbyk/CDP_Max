using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScalabiltyHomework.Contracts.Entities;

namespace Contracts.Queuing.Messages
{
    public class AddHeroReadMessage : IMessage
    {
        public Hero Hero {get;set;}
    }
}
