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
            Create_FrequencyChart();
        }

        private void Draw_Rectangles(List<RectangleF> rectangleList)
        {
            Bitmap bitmap = (Bitmap)pictureBox1.Image;
            SolidBrush brush = new SolidBrush(Color.Blue);

            using (Graphics g = pictureBox1.CreateGraphics())
            {
                foreach (RectangleF rectangle in rectangleList)
                {
                    g.FillRectangle(brush, rectangle);

                }

            }
        }

        private void Create_FrequencyChart()
        {
            MyPI.AFserverName = "APBDPAP0043";
            MyPI.AFdatabaseName = "2004_NBG";
            MyPI.PIservername = "AFAHPAP0010";
            string pipointName = "N_MML12001LastTrip";

            GetRecordedValues getRecordedValues = new GetRecordedValues("*-7d", "*", pipointName, MyPI.PIservername);
            var valuelist = new SanitizeAFValues(getRecordedValues.ValueList).afValues;

            List<Tuple<string, int>> tupleList = new GetTupleList(valuelist).tupleList;

            var maximum_y = tupleList.Max(x => x.Item2);
            var barCount = tupleList.Count;

            int padding_x = 25;
            int padding_y = 25;

            int picturebox_x = pictureBox1.Width;
            int picturebox_y = pictureBox1.Height;

            int window_x = picturebox_x - padding_x * 2;
            int window_y = picturebox_y - padding_y * 2;

            float bar_x_ratio = (float)0.80;
            float bar_x = window_x / barCount * bar_x_ratio;

            float barspace_x = (1 - bar_x_ratio) * (window_x / barCount);

            float space_x = padding_x + barspace_x / 2;
            float start_x = space_x;

            List<RectangleF> rectangleList = new List<RectangleF>();

            for (int i = 0; i < barCount; i++)
            {
                int value_y = tupleList[i].Item2;
                float rectangle_y = value_y * window_y / maximum_y;
                RectangleF rectangle = new RectangleF(start_x, padding_y + (window_y - rectangle_y), bar_x, rectangle_y);
                rectangleList.Add(rectangle);
                start_x += bar_x + barspace_x;
            }

            Draw_Rectangles(rectangleList);

        }
    }
}
