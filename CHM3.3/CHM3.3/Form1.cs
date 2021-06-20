using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CHM3._3;

namespace CHM3._3
{
    public partial class Form1 : Form
    {
        PointF[] point1;
        PointF[] point2;
        PointF[] point3;

        Graphics g;
        double[] x = Program.x;
        double[] y = Program.y;
        double[] a1 = Program.a1;
        double[] a2 = Program.a2;
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            //float scal = 600;
            float scal = 70;
            g = this.CreateGraphics();
            
            g.TranslateTransform(500,1000);
            g.ScaleTransform(1, -1);
            point1 = new PointF[15];
            for (int i = 0; i < x.Length; i++)
            {
                point1[i] = new PointF((float)x[i] * scal, (float)Program.f1xx[i] * scal);
            }

            for (int i = 0; i < x.Length - 1; i++)
            {
                g.DrawLine(new Pen(Color.Blue), point1[i], point1[i + 1]);
            }
            point2 = new PointF[15];
            for (int i = 0; i < x.Length; i++)
            {
                point2[i] = new PointF((float)x[i] * scal, (float)Program.f2xx[i] * scal);
            }
            for (int i = 0; i < x.Length - 1; i++)
            {
                g.DrawLine(new Pen(Color.Red), point2[i], point2[i + 1]);
            }
            point3 = new PointF[15];
            for (int i = 0; i < x.Length; i++)
            {
                point3[i] = new PointF((float)x[i] * scal, (float)y[i] * scal);
            }
            for (int i = 0; i < x.Length - 1; i++)
            {
                g.DrawLine(new Pen(Color.Black), point3[i], point3[i + 1]);
            }
            g.DrawLine(new Pen(Color.Purple), new Point(0, 0), new Point(0, 1000));
            g.DrawLine(new Pen(Color.Purple), new Point(0, 0), new Point(1000, 0));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
