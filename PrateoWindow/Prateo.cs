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
            pictureBox1.Image = null;
            Create_FrequencyChart();
        }

        
        private void Create_FrequencyChart()
        {
            //MyPI.AFserverName = "APBDPAP0043";
            //MyPI.AFdatabaseName = "2004_NBG";
            MyPI.PIservername = comboBoxConnectedServers.SelectedItem.ToString();
            string pipointName = textBoxPiPoint.Text;
            string startTime = textBoxStartTime.Text;
            string endTime = textBoxEndTime.Text;
            
            GetRecordedValues getRecordedValues = new GetRecordedValues(startTime, endTime, pipointName, MyPI.PIservername);
            if(getRecordedValues.ValueList != null)
            {
                var valuelist = new SanitizeAFValues(getRecordedValues.ValueList).afValues;

                List<Tuple<string, int>> tupleList = new GetTupleList(valuelist).tupleList;

                var maximum_y = tupleList.Max(x => x.Item2);
                var barCount = tupleList.Count;

                int padding_x = 50;
                int padding_y = 50;

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

                Bitmap bitmapWithRectangle = Draw_Rectangles(rectangleList);
                Bitmap bitmapWithAxis = Draw_Axis(bitmapWithRectangle, padding_x, padding_y);
                Bitmap bitmapWithTicks = Draw_TickMarks(bitmapWithAxis, padding_x, padding_y, rectangleList);
                Bitmap bitmapWithLabels = Draw_Labels(bitmapWithTicks, padding_x, padding_y, rectangleList, tupleList);
                pictureBox1.Image = bitmapWithLabels;
            }
            else
            {
                using (new CenterWinDialog(this))
                {
                    MessageBox.Show("PI Point not found on the selected server", "Error");
                }
            }
        }

        private Bitmap Draw_Rectangles(List<RectangleF> rectangleList)
        {
            SolidBrush brush = new SolidBrush(Color.Blue);
            Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                foreach (RectangleF rectangle in rectangleList)
                {
                    g.FillRectangle(brush, rectangle);

                }

            }
            return bitmap;

        }

        private Bitmap Draw_Axis(Bitmap bitmap, int padding_x, int padding_y)
        {
            Pen blackPen = new Pen(Color.Black);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.DrawLine(blackPen, (float)padding_x, (float)padding_y, (float)padding_x, (float)(pictureBox1.Height - padding_y));
                g.DrawLine(blackPen, (float)padding_x, (float)(pictureBox1.Height - padding_y), (float)(pictureBox1.Width - padding_x), (float)(pictureBox1.Height - padding_y));
            }
            return bitmap;
        }

        private Bitmap Draw_TickMarks(Bitmap bitmap, int padding_x, int padding_y, List<RectangleF> rectangleList)
        {
            Pen blackPen = new Pen(Color.Black);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                foreach(RectangleF rectangle in rectangleList)
                {
                    float tick_x = rectangle.X + (rectangle.Width / 2);
                    float tick_y = (float)(pictureBox1.Height - padding_y);
                    g.DrawLine(blackPen, tick_x, tick_y, tick_x, tick_y + 5);
                }

            }
            return bitmap;
        }

        private Bitmap Draw_Labels(Bitmap bitmap, int padding_x, int padding_y, List<RectangleF> rectangleList, List<Tuple<string, int>> tupleList)
        {
            Pen blackPen = new Pen(Color.Black);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                Font font = new Font("Tahoma", 8);
                Brush brush = Brushes.Black;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                  
                for(int i = 0; i<rectangleList.Count; i++)
                {
                    string label_text = tupleList[i].Item1;
                    var label_size = g.MeasureString(label_text, font);
                    float midpoint_x = rectangleList[i].X + (rectangleList[i].Width / 2);
                    float midpoint_y = (float)(pictureBox1.Height - padding_y + 5);
                    g.DrawString(label_text, font, brush, midpoint_x - label_size.Width / 2, midpoint_y);
                }
            }
            return bitmap;
        }

        private void Fill_ComboBox()
        {
            GetConnectedServers getConnectedServers = new GetConnectedServers();
            var connectedServers = getConnectedServers.piServers;
            object[] itemObject = new object[connectedServers.Count];
            for(int i =0; i<connectedServers.Count;i++)
            {
                itemObject[i] = connectedServers[i].Name;
            }
            comboBoxConnectedServers.Items.AddRange(itemObject);
            comboBoxConnectedServers.SelectedItem = itemObject[0];
        }

        private void Prateo_Load(object sender, EventArgs e)
        {
            Fill_ComboBox();
        }
    }
}
