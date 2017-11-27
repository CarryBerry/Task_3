using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task_3.Billing_System.Classes;
using Task_3.EventHandlers;

namespace Task_3.Classes
{
    public class Station : IStation
    {
        private Billing Billing { get; }
        public delegate void SentData(BillingCallInfo callInfo);
        public event SentData SentDataEvent;

        private readonly CallingInteraction interaction = new CallingInteraction();
        private readonly IDictionary<PhoneNumber, IPort> usersData;
        private CallInfo callInfo;

        public Station(Billing billing)
        {
            Billing = billing;
            usersData = new Dictionary<PhoneNumber, IPort>();
            callInfo = new CallInfo();
            SentDataEvent += Billing.AddCallInfo;
        }

        public CallInfo GetInfoList()
        {
            return callInfo;
        }

        public void GetCallTime()
        {
            GetInfoList();
            var info = callInfo;
            Console.WriteLine("Calling starts in: {0}, ends in: {1}", info.TimeStartCall, info.TimeEndCall);
        }

        public void AddUsersData(ITerminal terminal)
        {
            var newPort = terminal.Port;
            newPort.CallEvent += Calling;
            newPort.AnswerEvent += Calling;
            newPort.EndCallEvent += Calling;
            usersData.Add(terminal.phoneNumber, newPort);
        }
        public void Calling(object sender, IEventArgsCalling e)
        {
            if (usersData.ContainsKey(e.TargetNumber) 
                && e.TargetNumber != e.Number
                || e is EventArgsEndCall)
            {
                IPort targetPort;
                IPort port;

                if (e is EventArgsEndCall)
                {
                    var callListFirst = callInfo;

                    if (callListFirst.CallerNumber == e.Number)
                    {
                        targetPort = usersData[callListFirst.TargetNumber];
                        port = usersData[callListFirst.CallerNumber];
                    }
                    else
                    {
                        port = usersData[callListFirst.TargetNumber];
                        targetPort = usersData[callListFirst.CallerNumber];
                    }
                }
                else
                {
                    targetPort = usersData[e.TargetNumber];
                    port = usersData[e.Number];
                }

                if (targetPort.PortState == PortState.Connected && port.PortState == PortState.Connected)
                {
                    CallInfo info;

                    if (e is EventArgsAnswer)
                    {
                        info = callInfo;
                        var answerArgs = (EventArgsAnswer)e;

                        targetPort.AnswerCall(answerArgs.Number, answerArgs.TargetNumber, answerArgs.CurrentState);
                        
                        Thread.Sleep(4000);
                        info.TimeEndCall = DateTime.Now;
                        GetCallTime();
                    }

                    if (e is EventArgsCall)
                    {
                        Terminal term = new Terminal();
                        var callArgs = (EventArgsCall)e;
                        info = new CallInfo(callArgs.Number, callArgs.TargetNumber, DateTime.Now, DateTime.Now);
                        callInfo = info;
                        targetPort.IncomingCall(callArgs.Number, callArgs.TargetNumber);
                    }

                    if (e is EventArgsEndCall)
                    {
                        var endArgs = (EventArgsEndCall)e;
                        info = callInfo;
                        
                        RespondState state = endArgs.CurrentState;

                        if (state == RespondState.Ending)
                        {
                            targetPort.AnswerCall(endArgs.Number, endArgs.TargetNumber, RespondState.Ending);
                        }
                       
                        else if (state == RespondState.Decline)
                        {
                            targetPort.AnswerCall(endArgs.Number, endArgs.TargetNumber, RespondState.Decline);
                            GetCallTime();
                        }
                        SentDataEvent?.Invoke(new BillingCallInfo(GetInfoList().CallerNumber, GetInfoList().TargetNumber
                            , GetInfoList().TimeStartCall, GetInfoList().TimeEndCall));
                    }
                }
                else
                {
                    interaction.CallingToDisconnectedTerminalMessage(e.TargetNumber);
                }
            }
            else if (!usersData.ContainsKey(e.TargetNumber))
            {
                interaction.CallingToNonExictentNumberMessage(e.TargetNumber);
            }
        }
    }
}
