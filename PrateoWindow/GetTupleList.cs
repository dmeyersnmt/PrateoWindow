using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSIsoft.AF.Asset;

namespace PrateoWindow
{
    public class GetTupleList
    {

        public List<Tuple<string, int>> tupleList;

        public GetTupleList(List<AFValue> _valueList)
        {
            GroupByValue(_valueList);
        }

        private void GroupByValue(List<AFValue> valueList)
        {
            tupleList = new List<Tuple<string, int>>();
            var q = valueList.GroupBy(x => x.Value);
            foreach (var i in q)
            {
                Tuple<string, int> tuple = new Tuple<string, int>(i.Key.ToString(), i.Count());
                tupleList.Add(tuple);
                //Console.WriteLine("{0};{1}", i.Key, i.Count());
            }
            tupleList = tupleList.OrderByDescending(y => y.Item2).ToList();
        }
    }
}
