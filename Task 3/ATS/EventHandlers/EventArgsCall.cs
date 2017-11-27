using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_3.Classes;

namespace Task_3.EventHandlers
{
    public class EventArgsCall : EventArgs, IEventArgsCalling
    {
        public PhoneNumber Number { get; }
        public PhoneNumber TargetNumber { get;}

        public EventArgsCall(PhoneNumber number, PhoneNumber target)
        {
            Number = number;
            TargetNumber = target;
        }
    }
}
