using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3.Classes
{
    public interface IStation
    {
        void GetCallTime();
        void AddUsersData(ITerminal terminal);
        CallInfo GetInfoList();
    }
}
