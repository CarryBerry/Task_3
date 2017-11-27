using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_3.Billing_System.Interfaces;
using Task_3.Classes;

namespace Task_3.Billing_System.Classes
{
    public class Billing : IBilling
    {
        private readonly IDictionary<PhoneNumber, Contract> billingDictionary;
        private readonly ICollection<BillingCallInfo> infoList;

        public Billing()
        {
            infoList = new List<BillingCallInfo>();
            billingDictionary = new Dictionary<PhoneNumber, Contract>();
        }

        public void AddCallInfo(BillingCallInfo info)
        {
            infoList.Add(info);
        }

        public ICollection<BillingCallInfo> GetInfoList()
        {
            return infoList;
        }

        public void RegisterContract(Contract contract)
        {
            billingDictionary.Add(contract.Number, contract);
        }

        public void TerminateContract(Contract contract)
        {
            billingDictionary.Remove(contract.Number);
        }

        public HistoryContainer GetReport(PhoneNumber telephoneNumber)
        {
            var calls = GetInfoList()
                .Where(x => x.Number == telephoneNumber || x.TargetNumber == telephoneNumber)
                .ToList();

            var report = new HistoryContainer();

            foreach (var call in calls)
            {
                CallType callType;
                PhoneNumber number;
                double cost;

                if (call.Number == telephoneNumber)
                {
                    callType = CallType.Outgoing;
                    number = call.TargetNumber;
                    cost = call.GetCost(billingDictionary
                        .Where(x => x.Key == telephoneNumber)
                        .Select(x => x.Value)
                        .ElementAt(0), call.TimeStartCall, call.TimeEndCall);
                }
                else
                {
                    callType = CallType.Incoming;
                    number = call.Number;
                    cost = 0;
                }

                var record = new History(billingDictionary
                    .Where(x => x.Key == telephoneNumber)
                    .Select(x => x.Key)
                    .ElementAt(0), callType, call.TimeStartCall, new DateTime((call.TimeEndCall - call.TimeStartCall).Ticks), cost);

                report.AddRecord(record);
            }
            return report;
        }

        public double PayInvoice(Contract contract, int monthNumber)
        {
            double summ;
            var listRecords = GetReport(contract.Number).GetRecords();
            var allCallCost = listRecords
                .Where(x => x.Date.Month == monthNumber)
                .Where(x => x.CallType == CallType.Outgoing)
                .Select(x => x.Cost)
                .Sum();
            
            if (contract.tariffPlan.FreeMinutesInMonth * contract.tariffPlan.CallingCostPerMinute >= allCallCost)
            {
                summ = contract.tariffPlan.TariffCost;
            }
            else
            {
                summ = contract.tariffPlan.TariffCost + allCallCost - (contract.tariffPlan.FreeMinutesInMonth * contract.tariffPlan.CallingCostPerMinute);
            }
            return summ;
        }
    }
}
