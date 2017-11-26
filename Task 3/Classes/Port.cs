using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_3.EventHandlers;

namespace Task_3.Classes
{
    public class Port : IPort
    {
        private bool connectionStatus;
        private PortState portState;

        public PortState PortState
        {
            get { return portState; }
            set { portState = value; }
        }

        public Port()
        {
            PortState = PortState.Disconnected;
        }

        public bool Connect(Terminal terminal)
        {
            if (PortState == PortState.Disconnected)
            {                          
                PortState = PortState.Connected;
                connectionStatus = true;
                terminal.CallEvent += Calling;
                terminal.AnswerEvent += Answer;
                terminal.EndCallEvent += EndCall;
            }
            return connectionStatus;
        }

        public bool Disconnect(Terminal terminal)
        {
            if (PortState == PortState.Connected)
            {
                PortState = PortState.Disconnected;
                connectionStatus = false;
                terminal.CallEvent -= Calling;
                terminal.AnswerEvent -= Answer;
                terminal.EndCallEvent -= EndCall;
            }
            return connectionStatus;
        }

        public void Calling(object sender, EventArgsCall e)
        {
            CallEvent?.Invoke(this, new EventArgsCall(e.Number, e.TargetNumber));
        }

        public void Answer(object sender, EventArgsAnswer e)
        {
            AnswerEvent?.Invoke(this, new EventArgsAnswer(e.Number, e.TargetNumber, e.CurrentState));
        }

        public void EndCall(object sender, EventArgsEndCall e)
        {
            EndCallEvent?.Invoke(this, new EventArgsEndCall(e.Number, e.TargetNumber, e.CurrentState));
        }

        public void IncomingCall(PhoneNumber number, PhoneNumber targetNumber)
        {
            CallPortEvent?.Invoke(this, new EventArgsCall(number, targetNumber));
        }

        public void AnswerCall(PhoneNumber number, PhoneNumber targetNumber, RespondState state)
        {
            AnswerPortEvent?.Invoke(this, new EventArgsAnswer(number, targetNumber, state));
        }

        public event EventHandler<EventArgsCall> CallPortEvent;
        public event EventHandler<EventArgsAnswer> AnswerPortEvent;
        public event EventHandler<EventArgsAnswer> AnswerEvent;
        public event EventHandler<EventArgsEndCall> EndCallEvent;
        public event EventHandler<EventArgsCall> CallEvent;
    }
}
