using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3.Classes
{
    public class CallInfo
    {
        public PhoneNumber CallerNumber { get; }
        public PhoneNumber TargetNumber { get; }
        public DateTime TimeStartCall { get; set; }
        public DateTime TimeEndCall { get; set; }

        public CallInfo(PhoneNumber number, PhoneNumber targetNumber, DateTime beginCall, DateTime endCall)
        {
            CallerNumber = number;
            TargetNumber = targetNumber;
            TimeStartCall = beginCall;
            TimeEndCall = endCall;
        }

        public CallInfo()
        {
        }
    }
}
