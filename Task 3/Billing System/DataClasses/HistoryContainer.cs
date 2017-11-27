using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3.Billing_System.Classes
{
    public class HistoryContainer
    {
        private readonly IList<History> _listTapes;

        public HistoryContainer()
        {
            _listTapes = new List<History>();
        }

        public HistoryContainer(IList<History> listTapes)
        {
            _listTapes = listTapes;
        }

        public void AddRecord(History tape)
        {
            _listTapes.Add(tape);
        }

        public void RemoveRecord(History tape)
        {
            _listTapes.Remove(tape);
        }

        public IList<History> GetRecords()
        {
            return _listTapes;
        }

        public IList<History> SortByCallType()
        {
            return _listTapes
                    .OrderBy(x => x.CallType)
                    .ToList();
        }

        public IList<History> SortByDate()
        {
            return _listTapes
                    .OrderBy(x => x.Date)
                    .ToList();
        }

        public IList<History> SortByNumber()
        {
            return _listTapes
                    .OrderBy(x => x.ContractNumber)
                    .ToList();
        }

        public IList<History> SortByCost()
        {
            return _listTapes
                    .OrderBy(x => x.Cost)
                    .ToList();
        }
    }
}
