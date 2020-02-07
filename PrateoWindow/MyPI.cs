using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSIsoft.AF.PI;
using OSIsoft.AF;

namespace PrateoWindow
{
    public class MyPI
    {
        /// <summary>
        /// Class for setting up the pi system
        /// </summary>
        public static PISystems myPISystems = new PISystems();
        public static string AFdatabaseName { get; set; }
        public static string AFserverName { get; set; }
        public static string PIservername { get; set; }

        public static AFDatabase AF_DataBase
        {
            get
            {
                return myPISystems[AFserverName].Databases[AFdatabaseName];
            }
        }
        public static PISystem piSystem
        {
            get
            {
                return myPISystems[AFserverName];
            }
        }
        public static PIServer PI_Server => PIServer.FindPIServer(PIservername);
    }
}
