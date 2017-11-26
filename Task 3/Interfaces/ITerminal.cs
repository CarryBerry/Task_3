using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_3.Classes;
using Task_3.EventHandlers;

namespace Task_3.Classes
{
    public interface ITerminal
    {
        PhoneNumber phoneNumber { get; }
        IPort Port { get; }

        void CallingTo(PhoneNumber targetNumber);
        void EndCall(PhoneNumber targetNumber, RespondState state);
        void TakeIncomingCall(object sender, EventArgsCall e);
        void SetPortConnected();
        void SetPortDisconnected();
        
        event EventHandler<EventArgsCall> CallEvent;
        event EventHandler<EventArgsAnswer> AnswerEvent;
        event EventHandler<EventArgsEndCall> EndCallEvent;
    }
}
