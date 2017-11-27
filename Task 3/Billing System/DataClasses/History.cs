using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_3.Classes;

namespace Task_3.Billing_System.Classes
{
    public class History
    {
        public CallType CallType { get; }
        public PhoneNumber ContractNumber { get; }
        public DateTime Date { get; }
        public DateTime CallDuration { get; }
        public double Cost { get; }

        public History(PhoneNumber contractNumber, CallType type, DateTime date, DateTime callDuration, double cost)
        {
            ContractNumber = contractNumber;
            CallType = type;
            Date = date;
            CallDuration = callDuration;
            Cost = cost;
        }
    }
}
