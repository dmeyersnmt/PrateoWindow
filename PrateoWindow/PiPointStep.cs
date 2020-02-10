using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSIsoft.AF.PI;

namespace PrateoWindow
{
    public class PiPointStep
    {
        public object step { get; set; }


        public PiPointStep(string piPointName, string piServerName)
        {
            FindPIPoint findPIPoint = new FindPIPoint(piPointName, piServerName);
            PIPoint piPoint = findPIPoint.piPoint;

            piPoint.LoadAttributes(PICommonPointAttributes.Step);

            step = piPoint.GetAttribute(PICommonPointAttributes.Step);
        }
    }
}
