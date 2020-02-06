using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PrateoWindow
{
    public class CreateFrequencyChart
    {
        List<Tuple<string, int>> tupleList;
        int barCount
        {
            get
            {
                return tupleList.Count;
            }
        }
        int maximum_y
        {
            get
            {
                return tupleList.Max(x => x.Item2);
            }
        }

        int padding_x = 50;
        int padding_y = 50;
        float bar_x_ratio = (float)0.80;

        int picturebox_x;
        int picturebox_y;
        int window_x
        {
            get
            {
                return picturebox_x - padding_x * 2;
            }
        }
        int window_y
        {
            get
            {
                return picturebox_y - padding_y * 2;
            }
        }
        float bar_x
        {
            get
            {
                return window_x / barCount * bar_x_ratio;
            }
        }
        float barspace_x
        {
            get
            {
                return (1 - bar_x_ratio) * (window_x / barCount);
            }
        
        }
        
        float space_x
        {
            get
            {
                return padding_x + barspace_x / 2;
            }
        }
        float start_x;

        public Bitmap bitmap
        {
            get;set;
        }
        

        List<RectangleF> rectangleList = new List<RectangleF>();
    
        public CreateFrequencyChart(int _picturebox_x, int _picturebox_y, List<Tuple<string, int>> _tupleList)
        {
            picturebox_x = _picturebox_x;
            picturebox_y = _picturebox_y;
            bitmap = new Bitmap(picturebox_x, picturebox_y);
            tupleList = _tupleList;
            Create_RectangleList();
            Draw_Rectangles();
            Draw_Axis();
            Draw_TickMarks();
            Draw_Labels();
        }

    
        private void Create_RectangleList()
        {
            start_x = space_x;
            for(int i=0;i<barCount;i++)
            {
                int value_y = tupleList[i].Item2;
                float rectangle_y = value_y * window_y / maximum_y;
                RectangleF rectangle = new RectangleF(start_x, padding_y + (window_y - rectangle_y), bar_x, rectangle_y);
                rectangleList.Add(rectangle);
                start_x += bar_x + barspace_x;
            }
        }

        private void Draw_Rectangles()
        {
            SolidBrush brush = new SolidBrush(Color.Blue);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                foreach (RectangleF rectangle in rectangleList)
                {
                    g.FillRectangle(brush, rectangle);

                }
            }
        }
        
        private void Draw_Axis()
        {
            Pen blackPen = new Pen(Color.Black);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.DrawLine(blackPen, (float)padding_x, (float)padding_y, (float)padding_x, (float)(picturebox_y - padding_y));
                g.DrawLine(blackPen, (float)padding_x, (float)(picturebox_y - padding_y), (float)(picturebox_x - padding_x), (float)(picturebox_y - padding_y));
            }

        }

        private void Draw_TickMarks()
        {
            Pen blackPen = new Pen(Color.Black);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                foreach (RectangleF rectangle in rectangleList)
                {
                    float tick_x = rectangle.X + (rectangle.Width / 2);
                    float tick_y = (float)(picturebox_y - padding_y);
                    g.DrawLine(blackPen, tick_x, tick_y, tick_x, tick_y + 5);
                }

            }
        }

        private void Draw_Labels()
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

                for (int i = 0; i < rectangleList.Count; i++)
                {
                    string label_text = tupleList[i].Item1;
                    var label_x_size = g.MeasureString(label_text, font);
                    float midpoint_x = rectangleList[i].X + (rectangleList[i].Width / 2);
                    float midpoint_y = (float)(picturebox_y - padding_y + 5);
                    g.DrawString(label_text, font, brush, midpoint_x - label_x_size.Width / 2, midpoint_y);

                    string label_y_text = tupleList[i].Item2.ToString();
                    var label_y_size = g.MeasureString(label_y_text, font);
                    g.DrawString(label_y_text, font, brush, midpoint_x - label_y_size.Width / 2, rectangleList[i].Y - label_y_size.Height);
                }
            }
        }


    
    }
}
