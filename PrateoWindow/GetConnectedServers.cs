using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSIsoft.AF.PI;
using OSIsoft.AF;

namespace PrateoWindow
{
    public class GetConnectedServers
    { 

        public PIServers piServers
        {
            get
            {
                return new PIServers();
            }
        }
    }
}
