using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_3.Classes;

namespace Task_3.EventHandlers
{
    public interface IEventArgsCalling
    {
        PhoneNumber Number { get; }
        PhoneNumber TargetNumber { get;}
    }
}
