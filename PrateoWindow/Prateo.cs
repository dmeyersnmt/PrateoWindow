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
            Write_ToConsole("Application Loaded");
            Fill_ComboBox();
        }

        private void button_Build_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            Write_ToConsole("Fetching data from PI Server...");
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
            Write_ToConsole("Number of connected PI Servers found: " + connectedServers.Count);
        }


        private void Prepare_FrequencyChart()
        {
            MyPI.PIservername = comboBoxConnectedServers.SelectedItem.ToString();
            string pipointName = textBoxPiPoint.Text;
            string startTime = textBoxStartTime.Text;
            string endTime = textBoxEndTime.Text;
            if(comboBoxConnectedServers.SelectedItem == null)
            {
                Write_ToConsole("ERROR: No pi server selected.  Make sure that a connection to the PI server exists in PI SMT or AboutPI-SDK");
                using (new CenterWinDialog(this))
                {
                    MessageBox.Show("No PI Server Selected", "Error");
                }

            }
            else
            {
                GetRecordedValues getRecordedValues = new GetRecordedValues(startTime, endTime, pipointName, MyPI.PIservername);
                if (getRecordedValues.CheckAFTimeValues(startTime) && getRecordedValues.CheckAFTimeValues(endTime))
                {
                    if (getRecordedValues.ValueList != null)
                    {
                        Write_ToConsole("Total number of events found: " + getRecordedValues.ValueList.Count);
                        var valuelist = new SanitizeAFValues(getRecordedValues.ValueList).afValues;
                        //Write_ToConsole("Cleaning data...");
                        List<Tuple<string, int>> tupleList = new GetTupleList(valuelist).tupleList;
                        if (tupleList.Count > 0)
                        {
                            Write_ToConsole("Number of good quality events found: " + valuelist.Count);
                            CreateFrequencyChart createFrequencyChart = new CreateFrequencyChart(pictureBox1.Width, pictureBox1.Height, tupleList);
                            pictureBox1.Image = createFrequencyChart.bitmap;
                            Write_ToConsole("Finished building frequency chart");
                        }
                        else
                        {
                            using (new CenterWinDialog(this))
                            {
                                Write_ToConsole("ERROR: No events found for specified time range");
                                MessageBox.Show("No events found for specifed time range", "Error");
                            }
                        }
                    }
                    else
                    {
                        using (new CenterWinDialog(this))
                        {
                            Write_ToConsole("ERROR: PI Point not found on the selected server");
                            MessageBox.Show("PI Point not found on the selected server", "Error");
                        }
                    }
                }
                else
                {
                    using (new CenterWinDialog(this))
                    {
                        Write_ToConsole("ERROR: Unable to parse AFTime.  Try another time format");
                        MessageBox.Show("Invalid AFTime", "Error");
                    }
                }
            }
        }

        private void Write_ToConsole(string text)
        {
            string output = String.Format("{0}: {1}", DateTime.Now, text+"\r\n");
            textBoxConsole.AppendText(output);

        }
    }
}
