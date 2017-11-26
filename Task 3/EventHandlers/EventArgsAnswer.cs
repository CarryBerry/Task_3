using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_3.Classes;

namespace Task_3.EventHandlers
{
    public class EventArgsAnswer : EventArgs, IEventArgsCalling
    {
        public PhoneNumber TargetNumber { get; }
        public PhoneNumber Number { get; }
        public RespondState CurrentState { get; }

        public EventArgsAnswer(PhoneNumber number, PhoneNumber phoneTarget, RespondState state)
        {
            Number = number;
            TargetNumber = phoneTarget;
            CurrentState = state;
        }

    }
}