using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_3.Billing_System.Classes;

namespace Task_3.Billing_System.Interfaces
{
    public interface IContract
    {
        int ContractNumber { get; }
        DateTime ContractDate { get; }
        TariffPlan tariffPlan { get; }
    }
}
