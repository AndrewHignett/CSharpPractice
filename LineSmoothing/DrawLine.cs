using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LineSmoothing
{
    public partial class DrawLine : Form
    {
        Graphics g;
        int x = -1;
        int y = -1;
        bool moving = false;
        Pen pen;
        int thisColour = 0;
        Color[] colours = {Color.Black, Color.Red, Color.Green, Color.Blue, Color.Cyan, Color.Magenta, Color.Yellow };
        int brushWidth = 10;

        public DrawLine()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            pen = new Pen(colours[thisColour], brushWidth);
            pen.StartCap = LineCap.Round;
            pen.EndCap = LineCap.Round;
            pen.LineJoin = LineJoin.Round;
            //We want to be able to change the colour on each redraw of a line
            //Our lines can currently draw only from left to right - this is intentional
            //This would make the pen unuseable
            //pen.Dispose()
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            if (e.X > x)
            {
                x = e.X;
                y = e.Y;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            thisColour++;
            if (thisColour < colours.Length)
            {
                pen.Color = colours[thisColour];
            }
            x = -1;
            y = -1;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving && x != -1 && y != -1)
            {
                if (e.X > x && thisColour < colours.Length)
                {
                    g.DrawLine(pen, new Point(x, y), e.Location);
                    x = e.X;
                    y = e.Y;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //these should get dimensionns from the panel instead rather than from here
            Bitmap img = DrawControlToBitmap(panel1);
            img.Save(".\\Lines\\temp\\LineTemp.png");
            LineImage aLineImage = new LineImage(panel1.Width, panel1.Height, img);
            aLineImage.SaveLine();
        }

        //Generalised method for saving images of particular parts of the window
        private Bitmap DrawControlToBitmap(Control control)
        {
            Bitmap bitmap = new Bitmap(control.Width, control.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            Rectangle rect = control.RectangleToScreen(control.ClientRectangle);
            graphics.CopyFromScreen(rect.Location, Point.Empty, control.Size);
            return bitmap;
        }
    }
}
