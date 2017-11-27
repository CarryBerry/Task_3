using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3.Billing_System.Interfaces
{
    public interface ICustomer
    {
        string FirstName { get; }
        string LastName { get; }
        double Balance { get; }
        void IcreaseBalance(double amount);
        void DecreaseBalance(double amount);
        double GetBalance();
    }
}
