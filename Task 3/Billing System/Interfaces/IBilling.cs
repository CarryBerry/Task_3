using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_3.Billing_System.Classes;
using Task_3.Classes;

namespace Task_3.Billing_System.Interfaces
{
    public interface IBilling
    {
        HistoryContainer GetReport(PhoneNumber phoneNumber);
    }
}
