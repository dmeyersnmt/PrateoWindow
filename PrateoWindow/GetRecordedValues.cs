using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSIsoft.AF.Asset;
using OSIsoft.AF.Data;
using OSIsoft.AF.Time;
using OSIsoft.AF.PI;

namespace PrateoWindow
{
    public class GetRecordedValues
    {
        string afStart;
        string afEnd;
        string piPointName;
        string piServerName;
        AFTimeRange afTimeRange
        {
            get
            {
                return new AFTimeRange(afStart, afEnd);
            }
        }
        PIPoint piPoint
        {
            get
            {
                return new FindPIPoint(piPointName, piServerName).piPoint;
            }
        }
        public List<AFValue> ValueList
        {
            get
            {
                if(piPoint!=null)
                {
                    return piPoint.RecordedValues(afTimeRange, AFBoundaryType.Inside, null, true);
                }
                else
                {
                    return null;
                }
                
            }
        }


        public GetRecordedValues(string _afStart, string _afEnd, string _piPointName, string _piServerName)
        {
            this.afStart = _afStart;
            this.afEnd = _afEnd;
            this.piPointName = _piPointName;
            this.piServerName = _piServerName;
        }
    }
}
