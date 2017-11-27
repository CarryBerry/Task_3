using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_3.Classes;

namespace Task_3.Billing_System.Classes
{
    public class HistorySorter
    {
        public void ShowSortedCallInfo(Billing billing, ITerminal terminal)
        {
            int actionStopper = 1;
            var listRecords = billing.GetReport(terminal.phoneNumber).GetRecords();
            HistoryContainer historyTapes = new HistoryContainer(listRecords);

            while (actionStopper > 0)
            {
                Console.WriteLine("Select the sort type:\n " +
                                  "ByDateOfCall (enter D),\n " +
                                  "ByCost (enter C),\n " +
                                  "ByNumber (enter N),\n " +
                                  "ByCallType (enter T),\n");
                var key = Console.ReadKey().Key;
                if (key == ConsoleKey.D)
                {
                    actionStopper = 0;
                    historyTapes.SortByDate();
                }
                else if (key == ConsoleKey.C)
                {
                    actionStopper = 0;
                    historyTapes.SortByCost();
                }
                else if (key == ConsoleKey.N)
                {
                    actionStopper = 0;
                    historyTapes.SortByNumber();
                }
                else if (key == ConsoleKey.T)
                {
                    actionStopper = 0;
                    historyTapes.SortByCallType();
                }
            }

            foreach (var item in historyTapes.GetRecords())
            {
                Console.WriteLine("\nCalls:\n Type {0} |\n Date: {1} |\n Duration: {2} | Cost: {3} | Number: {4}",
                    item.CallType, item.Date, item.CallDuration.ToString("mm:ss"), item.Cost, item.ContractNumber);
            }
        }
    }
}