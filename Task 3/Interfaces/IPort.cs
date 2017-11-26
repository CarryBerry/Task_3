using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_3.Classes;
using Task_3.EventHandlers;

namespace Task_3.Classes
{
    public interface IPort
    {
        PortState PortState { get; }

        bool Connect(Terminal terminal);
        bool Disconnect(Terminal terminal);
        void AnswerCall(PhoneNumber number, PhoneNumber targetNumber, RespondState state);
        void IncomingCall(PhoneNumber number, PhoneNumber targetNumber);
        
        event EventHandler<EventArgsCall> CallEvent;
        event EventHandler<EventArgsCall> CallPortEvent;
        event EventHandler<EventArgsAnswer> AnswerPortEvent;
        event EventHandler<EventArgsAnswer> AnswerEvent;
        event EventHandler<EventArgsEndCall> EndCallEvent;
    }
}
