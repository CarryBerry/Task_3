using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task_3.Billing_System.Classes;
using Task_3.Classes;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            HistoryContainer history = new HistoryContainer();

            HistorySorter sorter = new HistorySorter();

            Billing billing = new Billing();
            
            Station station = new Station(billing);

            Customer customer1 = new Customer("John", "Doe");
            Contract contract1 = new Contract(customer1, TariffType.Basic, DateTime.Now);
            IPort port1 = new Port();
            ITerminal terminal1 = new Terminal(contract1.Number, port1);

            Customer customer2 = new Customer("Dow", "Jones");
            Contract contract2 = new Contract(customer2, TariffType.Comfort, DateTime.Now);
            IPort port2 = new Port();
            ITerminal terminal2 = new Terminal(contract2.Number, port2);

            Customer customer3 = new Customer("Nas", "Daq");
            Contract contract3 = new Contract(customer3, TariffType.Business, DateTime.Now);
            IPort port3 = new Port();
            ITerminal terminal3 = new Terminal(contract3.Number, port3);

            billing.RegisterContract(contract1);
            billing.RegisterContract(contract2);
            billing.RegisterContract(contract3);

            station.AddUsersData(terminal1);
            station.AddUsersData(terminal2);
            station.AddUsersData(terminal3);

            terminal1.SetPortConnected();
            terminal2.SetPortConnected();
            terminal3.SetPortConnected();

            terminal1.CallingTo(terminal2.phoneNumber);
            terminal2.EndCall(terminal2.phoneNumber, RespondState.Ending);
            Console.WriteLine();

            terminal3.CallingTo(terminal1.phoneNumber);
            terminal1.EndCall(terminal1.phoneNumber, RespondState.Ending);
            Console.WriteLine();

            terminal1.CallingTo(terminal3.phoneNumber);
            terminal3.EndCall(terminal1.phoneNumber, RespondState.Ending);
            Console.WriteLine();

            terminal2.SetPortDisconnected();
            terminal1.CallingTo(terminal2.phoneNumber);
            Console.WriteLine();

            Console.WriteLine("Invoice for payment: {0}", billing.PayInvoice(contract1, DateTime.Now.Month));
            
            Console.WriteLine("Current balance: {0}", customer1.GetBalance());

            customer1.DecreaseBalance(billing.PayInvoice(contract1, DateTime.Now.Month));
            Console.WriteLine("Monthly payment accepted.");
            
            Console.WriteLine("Current balance: {0}", customer1.GetBalance());

            customer1.IcreaseBalance(30);
            Console.WriteLine("Balance increased by 30 common units");
       
            Console.WriteLine("Current balance: {0}", customer1.GetBalance());

            Console.WriteLine();
            Console.WriteLine(contract1.ChangeTariff(TariffType.Comfort)
                ? "Tariff has changed."
                : "It's impossible to change tariff right now. Wait until {0}.", contract1.GetDateOfPossibleTariffChange());
            Console.WriteLine();

            sorter.ShowSortedCallInfo(billing, terminal1);

            Console.ReadKey();
        }
    }
}
