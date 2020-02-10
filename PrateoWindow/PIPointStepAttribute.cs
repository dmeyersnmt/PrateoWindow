using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSIsoft.AF.PI;

namespace PrateoWindow
{
    public class PIPointStepAttribute
    {
        public bool isStep { get; set; }
        
        public PIPointStepAttribute(string piPointName, string piServerName)
        {

            FindPIPoint findPIPoint = new FindPIPoint(piPointName, piServerName);
            PIPoint piPoint = findPIPoint.piPoint;

            piPoint.LoadAttributes(PICommonPointAttributes.Step);

            object step = piPoint.GetAttribute(PICommonPointAttributes.Step);
            if(Convert.ToInt32(step)==1)
            {
                isStep = true;
            }
            else
            {
                isStep = false;
            }
        }
    }
}
