using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_3.Classes;

namespace Task_3.EventHandlers
{
    public class EventArgsEndCall : EventArgs, IEventArgsCalling
    {
        public PhoneNumber Number { get; }
        public PhoneNumber TargetNumber { get;}
        public RespondState CurrentState { get; }

        public EventArgsEndCall (PhoneNumber number, PhoneNumber targetNumber, RespondState state)
        {
            Number = number;
            TargetNumber = targetNumber;
            CurrentState = state;
        }
    }
}
