using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSIsoft.AF.Asset;

namespace PrateoWindow
{
    public class HistoData
    {

        public HistoData(List<AFValue> _valueList)
        {
            GroupByValue(_valueList);

        }

        private void GroupByValue(List<AFValue> valueList)
        {
            var q = valueList.GroupBy(x => x.Value);
            foreach (var i in q)
            {
                Console.WriteLine("{0};{1}", i.Key, i.Count());
            }

        }

    }
}
