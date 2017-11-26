using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task_3.Classes;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Station station = new Station();

            CallInfo inf = new CallInfo();

            PhoneNumber number1 = new PhoneNumber(111);
            PhoneNumber number2 = new PhoneNumber(222);
            PhoneNumber number3 = new PhoneNumber(333);
            PhoneNumber number4 = new PhoneNumber(444);

            IPort port1 = new Port();
            ITerminal terminal1 = new Terminal(number1, port1);
           
            IPort port2 = new Port();
            ITerminal terminal2 = new Terminal(number2, port2);

            IPort port3 = new Port();
            ITerminal terminal3 = new Terminal(number3, port3);

            station.AddUsersData(terminal1);
            station.AddUsersData(terminal2);
            station.AddUsersData(terminal3);

            terminal1.SetPortConnected();
            terminal2.SetPortConnected();
            terminal3.SetPortConnected();

            terminal1.CallingTo(number2);
            terminal2.EndCall(number2, RespondState.Ending);
            Console.WriteLine();

            terminal3.CallingTo(number1);
            terminal1.EndCall(number1, RespondState.Ending);
            Console.WriteLine();
            
            terminal2.SetPortDisconnected();
            terminal1.CallingTo(number2);
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
