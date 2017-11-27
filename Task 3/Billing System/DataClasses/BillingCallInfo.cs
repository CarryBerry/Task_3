using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_3.Billing_System.Interfaces;
using Task_3.Classes;

namespace Task_3.Billing_System.Classes
{
    public class BillingCallInfo
    {
        public PhoneNumber Number { get; }
        public PhoneNumber TargetNumber { get; }
        public DateTime TimeStartCall { get; }
        public DateTime TimeEndCall { get; }
        public double Cost { get; }
        
        public BillingCallInfo(PhoneNumber number, PhoneNumber targetNumber, DateTime start, DateTime end, double cost)
        {
            Number = number;
            TargetNumber = targetNumber;
            TimeStartCall = start;
            TimeEndCall = end;
            Cost = cost;
        }

        public BillingCallInfo(PhoneNumber number, PhoneNumber targetNumber, DateTime start, DateTime end)
        {
            Number = number;
            TargetNumber = targetNumber;
            TimeStartCall = start;
            TimeEndCall = end;
        }

        public double GetCost(Contract contract, DateTime start, DateTime end)
        {
            long durationTicks = end.Ticks - start.Ticks;
            TimeSpan duration = new TimeSpan(durationTicks);
            
            var callPrice = Math.Ceiling(duration.TotalMinutes) <=1
               ? contract.tariffPlan.CallingCostPerMinute
               : contract.tariffPlan.CallingCostPerMinute * Math.Ceiling(duration.TotalMinutes);
            return callPrice;
        }
    }
}
