using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_3.Billing_System.Interfaces;
using Task_3.Classes;

namespace Task_3.Billing_System.Classes
{
    public class Contract : IContract
    {
        private static readonly Random random = new Random();

        private DateTime dateOfLastTariffChange;
        
        public Customer Customer { get; }
        public int ContractNumber { get; }
        public DateTime ContractDate { get; }
        public TariffPlan tariffPlan { get; private set; }
        public PhoneNumber Number { get; }

        public Contract(Customer customer, TariffType type, DateTime contractDate)
        {
            Customer = customer;
            ContractNumber = random.Next(10000, 99999);
            Number = new PhoneNumber(random.Next(100, 999));
            tariffPlan = new TariffPlan(type);
            ContractDate = contractDate;
            dateOfLastTariffChange = DateTime.Now;
        }

        public DateTime GetDateOfPossibleTariffChange()
        {
            return dateOfLastTariffChange.AddMonths(1);
        }

        public bool ChangeTariff(TariffType type)
        {
            if (DateTime.Now.AddMonths(-1) < dateOfLastTariffChange)
            {
                return false;
            }
            else
            { 
                dateOfLastTariffChange = DateTime.Now;
                tariffPlan = new TariffPlan(type);
                return true;
            }
        }
    }
}
