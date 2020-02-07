using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSIsoft.AF.PI;


namespace PrateoWindow
{
    /// <summary>
    /// Class for retrieving a PI Point from a PI Server.  
    /// Returns null if no pi point found
    /// </summary>
    public class FindPIPoint
    {
        string pointName;
        string serverName;

        public PIPoint piPoint
        {
            get 
            {
                try
                {
                    return PIPoint.FindPIPoint(MyPI.PI_Server, pointName);
                }
                catch
                {
                    return null;
                }
            }
        }

        public FindPIPoint(string _pointName, string _serverName)
        {
            pointName = _pointName;
            serverName = _serverName;
            MyPI.PIservername = serverName;
        }
    }
}
