using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3.Classes
{
    public class PhoneNumber 
    {
        private readonly int _phoneNumber;

        public int Value
        {
            get { return _phoneNumber; }
        }

        public PhoneNumber(int phoneNumber)
        {
            _phoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
