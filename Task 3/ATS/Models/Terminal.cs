using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_3.EventHandlers;

namespace Task_3.Classes
{
    public class Terminal : ITerminal
    {
        public PhoneNumber phoneNumber { get; }
        public IPort Port { get; }

        private readonly CallingInteraction interaction = new CallingInteraction();

        public Terminal()
        {
        }

        public Terminal(PhoneNumber number, IPort port)
        {
            phoneNumber = number;
            Port = port;
        }

        public void CallingTo(PhoneNumber targetNumber)
        {
            if (targetNumber != phoneNumber)
            {
                CallEvent?.Invoke(this, new EventArgsCall(phoneNumber, targetNumber));
            }
            else
            {
                interaction.CallingToYourselfMessage(targetNumber);
            }
        }

        public void AnswerCall(PhoneNumber targetNumber, RespondState state)
        {
            AnswerEvent?.Invoke(this, new EventArgsAnswer(phoneNumber, targetNumber, state));
        }

        public void EndCall(PhoneNumber targetNumber, RespondState state)
        {
            EndCallEvent?.Invoke(this, new EventArgsEndCall(phoneNumber, targetNumber, state));
        }

        public void TakeIncomingCall(object sender, EventArgsCall e)
        {
            var param = interaction.AnswerChoice(e.Number, e.TargetNumber, RespondState.State);
           
            if (param == RespondState.Accept)
            {
                AnswerCall(e.Number, RespondState.Accept);
            }
            else if (param == RespondState.Decline)
            {
                EndCall(e.TargetNumber, RespondState.Decline);
            }
        }

        public void TakeAnswer(object sender, EventArgsAnswer e)
        {
            interaction.AnswerMessage(e.CurrentState, e.Number, e.TargetNumber);
        }

        public void SetPortConnected()
        {
            if (Port.Connect(this))
            {
                Port.CallPortEvent += TakeIncomingCall;
                Port.AnswerPortEvent += TakeAnswer;
            }
        }

        public void SetPortDisconnected()
        {
            if (Port.Disconnect(this))
            {
                Port.CallPortEvent -= TakeIncomingCall;
                Port.AnswerPortEvent -= TakeAnswer;
            }
        }

        public event EventHandler<EventArgsCall> CallEvent;
        public event EventHandler<EventArgsAnswer> AnswerEvent;
        public event EventHandler<EventArgsEndCall> EndCallEvent;
    }
}
