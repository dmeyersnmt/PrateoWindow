using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSIsoft.AF.PI;


namespace PrateoWindow
{
    public class FindPIPoint
    {
        string pointName;
        string serverName;

        public PIPoint piPoint
        {
            get { return PIPoint.FindPIPoint(MyPI.PI_Server, pointName); }
        }

        public FindPIPoint(string _pointName, string _serverName)
        {
            pointName = _pointName;
            serverName = _serverName;
            MyPI.PIservername = serverName;
        }
    }
}
