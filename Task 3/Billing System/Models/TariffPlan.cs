using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3.Billing_System.Classes
{
    public class TariffPlan
    {
        public double TariffCost { get; }
        public double CallingCostPerMinute { get; }
        public int FreeMinutesInMonth { get; }

        public TariffPlan(TariffType tariffType)
        {
            var type = tariffType;
            int actionStopper = 1;
            while (actionStopper > 0)
            {
                if (type == TariffType.Basic)
                {
                    TariffCost = 5;
                    CallingCostPerMinute = 2;
                    FreeMinutesInMonth = 0;
                    actionStopper = 0;
                }

                else if (type == TariffType.Comfort)
                {
                    TariffCost = 20;
                    CallingCostPerMinute = 1;
                    FreeMinutesInMonth = 10;
                    actionStopper = 0;
                }

                else if (type == TariffType.Business)
                {
                    TariffCost = 40;
                    CallingCostPerMinute = 0.5;
                    FreeMinutesInMonth = 0;
                    actionStopper = 0;
                }
            }
        }
    }
}

