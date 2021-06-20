using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CHM3._2
{
    public partial class Form1 : Form
    {
        double[] x = Program.x; 
        PointF[] point1;
        Graphics g;
        public Form1()
        {
            InitializeComponent();
            g = this.CreateGraphics();
            g.TranslateTransform(100, 950);
            g.ScaleTransform(1, -1);

        }
        float scal = 500;

        private void button1_Click(object sender, EventArgs e)
        {
            g.Clear(DefaultBackColor);
            g = this.CreateGraphics();
            g.TranslateTransform(100, 950);
            g.ScaleTransform(1, -1);
            g.DrawString("1-", DefaultFont, new SolidBrush(Color.Red), 0, scal);
            g.DrawString("2-", DefaultFont, new SolidBrush(Color.Red), 0, 2*scal);
            for (int i = 0; i < x.Length; i++)
            {
                g.DrawString("+", DefaultFont, new SolidBrush(Color.Red), (float)x[i]*scal, 0);
            }
            point1 = new PointF[x.Length-1];
            for (int i = 1; i < x.Length; i++)
            {
                point1[i-1] = new PointF((float)x[i] * scal, (float)Program.F1(Program.A,Program.B,Program.c,Program.D,x,Program.X)[i] * scal);
            }
            
            g.DrawCurve(new Pen(Color.Blue,2), point1);
            for (int i = 1; i < point1.Length; i++)
            {
                g.DrawLine(new Pen(Color.Brown,2), point1[i - 1], point1[i]);
            }
            for (int i = 0; i < x.Length-1; i++)
            {
                g.DrawString("*", DefaultFont,new SolidBrush(Color.Red), point1[i]);
            }
            
            g.DrawLine(new Pen(Color.Purple), new Point(0, 0), new Point(0, 1000));//y
            g.DrawLine(new Pen(Color.Purple), new Point(-1000, 0), new Point(1000, 0));//x
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            g.Clear(DefaultBackColor);
            g = this.CreateGraphics();
            g.TranslateTransform(100, 950);
            g.ScaleTransform(1, -1);
            g.DrawString("1-", DefaultFont, new SolidBrush(Color.Red), 0, scal);
            g.DrawString("2-", DefaultFont, new SolidBrush(Color.Red), 0, 2 * scal);
            for (int i = 0; i < x.Length; i++)
            {
                g.DrawString("+", DefaultFont, new SolidBrush(Color.Red), (float)x[i] * scal, 0);
            }
            point1 = new PointF[x.Length - 1];
            for (int i = 1; i < x.Length; i++)
            {
                point1[i - 1] = new PointF((float)x[i] * scal, (float)Program.F1(Program.A, Program.B, Program.c, Program.D, x, Program.X)[i] * scal);
            }

           
            for (int i = 1; i < point1.Length; i++)
            {
                g.DrawLine(new Pen(Color.Brown, 2), point1[i - 1], point1[i]);
            }
            for (int i = 0; i < x.Length - 1; i++)
            {
                g.DrawString("*", DefaultFont, new SolidBrush(Color.Red), point1[i]);
            }

            g.DrawLine(new Pen(Color.Purple), new Point(0, 0), new Point(0, 1000));
            g.DrawLine(new Pen(Color.Purple), new Point(-1000, 0), new Point(1000, 0));

        }

        private void button3_Click(object sender, EventArgs e)
        {
            g.Clear(DefaultBackColor);
            g = this.CreateGraphics();
            g.TranslateTransform(100, 950);
            g.ScaleTransform(1, -1);
            g.DrawString("1-", DefaultFont, new SolidBrush(Color.Red), 0, scal);
            g.DrawString("2-", DefaultFont, new SolidBrush(Color.Red), 0, 2 * scal);
            for (int i = 0; i < x.Length; i++)
            {
                g.DrawString("+", DefaultFont, new SolidBrush(Color.Red), (float)x[i] * scal, 0);
            }
            point1 = new PointF[x.Length - 1];
            for (int i = 1; i < x.Length; i++)
            {
                point1[i - 1] = new PointF((float)x[i] * scal, (float)Program.F1(Program.A, Program.B, Program.c, Program.D, x, Program.X)[i] * scal);
            }

            g.DrawCurve(new Pen(Color.Blue, 2), point1);
            
            for (int i = 0; i < x.Length - 1; i++)
            {
                g.DrawString("*", DefaultFont, new SolidBrush(Color.Red), point1[i]);
            }

            g.DrawLine(new Pen(Color.Purple), new Point(0, 0), new Point(0, 1000));
            g.DrawLine(new Pen(Color.Purple), new Point(-1000, 0), new Point(1000, 0));
            
        }
    }
}
