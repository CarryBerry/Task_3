using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_3.Billing_System.Interfaces;

namespace Task_3.Billing_System.Classes
{
    public class Customer : ICustomer
    {
        public string FirstName { get; }
        public string LastName { get; }
        public double Balance { get; private set; }

        public Customer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Balance = 500;
        }

        public void IcreaseBalance(double amount)
        {
            Balance += amount;
        }

        public void DecreaseBalance(double amount)
        {
            Balance -= amount;
        }

        public double GetBalance()
        {
            return Balance;
        }
    }
}
