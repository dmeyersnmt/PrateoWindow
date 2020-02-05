using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrateoWindow
{
    public partial class Prateo : Form
    {
        public Prateo()
        {
            InitializeComponent();
        }

        private void button_Build_Click(object sender, EventArgs e)
        {
            MyPI.AFserverName = "APBDPAP0043";
            MyPI.AFdatabaseName = "2004_NBG";
            MyPI.PIservername = "AFAHPAP0010";
            string pipointName = "N_MML12001LastTrip";

            GetRecordedValues getRecordedValues = new GetRecordedValues("*-7d", "*", pipointName, MyPI.PIservername);
            var valuelist = new SanitizeAFValues(getRecordedValues.ValueList).afValues;

            List<Tuple<string, int>> tupleList = new GetTupleList(valuelist).tupleList;

        }
    }
}
