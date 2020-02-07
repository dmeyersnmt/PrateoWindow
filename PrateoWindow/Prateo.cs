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

        private void Prateo_Load(object sender, EventArgs e)
        {
            Fill_ComboBox();
        }

        private void button_Build_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            Prepare_FrequencyChart();
        }

        private void Fill_ComboBox()
        {
            GetConnectedServers getConnectedServers = new GetConnectedServers();
            var connectedServers = getConnectedServers.piServers;
            object[] itemObject = new object[connectedServers.Count];
            for (int i = 0; i < connectedServers.Count; i++)
            {
                itemObject[i] = connectedServers[i].Name;
            }
            comboBoxConnectedServers.Items.AddRange(itemObject);
            comboBoxConnectedServers.SelectedItem = itemObject[0];
        }


        private void Prepare_FrequencyChart()
        {
            MyPI.PIservername = comboBoxConnectedServers.SelectedItem.ToString();
            string pipointName = textBoxPiPoint.Text;
            string startTime = textBoxStartTime.Text;
            string endTime = textBoxEndTime.Text;

            GetRecordedValues getRecordedValues = new GetRecordedValues(startTime, endTime, pipointName, MyPI.PIservername);
            if (getRecordedValues.CheckAFTimeValues(startTime) && getRecordedValues.CheckAFTimeValues(endTime))
            {
                if (getRecordedValues.ValueList != null)
                {
                    var valuelist = new SanitizeAFValues(getRecordedValues.ValueList).afValues;
                    List<Tuple<string, int>> tupleList = new GetTupleList(valuelist).tupleList;
                    if(tupleList.Count>0)
                    {
                        CreateFrequencyChart createFrequencyChart = new CreateFrequencyChart(pictureBox1.Width, pictureBox1.Height, tupleList);
                        pictureBox1.Image = createFrequencyChart.bitmap;
                    }
                    else
                    {
                        using (new CenterWinDialog(this))
                        {
                            MessageBox.Show("No events found for specifed time range", "Error");
                        }
                    }
                }
                else
                {
                    using (new CenterWinDialog(this))
                    {
                        MessageBox.Show("PI Point not found on the selected server", "Error");
                    }
                }
            }
            else
            {
                using (new CenterWinDialog(this))
                {
                    MessageBox.Show("Invalid AFTime", "Error");
                }
            }
        }
    }
}
