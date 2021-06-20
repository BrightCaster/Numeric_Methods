using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHM3._4
{
    class Program
    {
        static void Main(string[] args)
        {
            //double[] x = new double[] { 0.0, 0.10, 0.20, 0.30, 0.40 };
            //double[] y = new double[] { 1.0, 1.1052, 1.2214, 1.3499, 1.4918 };
            //double X = 0.2;
            double[] x = new double[] { -1.0, 0.0, 1.0, 2.0, 3.0 };
            double[] y = new double[] { 1.3562, 1.5708, 1.7854, 2.4636, 3.3218 };
            double X = 1.0;
            double[] dyy = new double[x.Length];
            for(int i = 0; i < x.Length-1; i++) 
            {
                dyy[i] = (y[i+1]-y[i])/(x[i+1]-x[i]);
            }
            double[] dy = new double[x.Length];
            List<double> ddyy = new List<double>();
            for (int i = 0; i < x.Length - 1; i++)
            {
                if (dyy[i] == 0) continue;
                else ddyy.Add(dyy[i]);
            }
            dy = ddyy.ToArray();
            Console.WriteLine("Производная с первым порядком точности:");
            for (int i = 0; i < dy.Length; i++)
            {
                Console.Write($"{dy[i]}\t");
            }
            Console.WriteLine();
            ddyy.Clear();
            dyy[0] = (y[1] - y[0]) / (x[1] - x[0]) + ((y[2] - y[1]) / (x[2] - x[1]) - (y[1] - y[0]) / (x[1] - x[0])) / (x[2] - x[0]) * ((X - x[1]) + (X - x[0])) + ((((y[3] - y[2]) / (x[3] - x[2]) - (y[2] - y[1]) / (x[2] - x[1])) / (x[3] - x[1])) - (((y[2] - y[1]) / (x[2] - x[1]) - (y[1] - y[0]) / (x[1] - x[0])) / (x[2] - x[0]))) / (x[3] - x[0]) * ((X - x[1]) * (X - x[2]) + (X - x[0]) * (X - x[2]) + (X - x[0]) * (X - x[1])) + (((((y[4] - y[3]) / (x[4] - x[3]) - (y[3] - y[2]) / (x[3] - x[2])) / (x[4] - x[2])) - (((y[3] - y[2]) / (x[3] - x[2]) - (y[2] - y[1]) / (x[2] - x[1])) / (x[3] - x[1]))) / (x[4] - x[1]) - ((((y[3] - y[2]) / (x[3] - x[2]) - (y[2] - y[1]) / (x[2] - x[1])) / (x[3] - x[1])) - (((y[2] - y[1]) / (x[2] - x[1]) - (y[1] - y[0]) / (x[1] - x[0])) / (x[2] - x[0]))) / (x[3] - x[0])) / (x[4] - x[0]) * ((X - x[2]) * (X - x[3]) + (X - x[1]) * (X - x[3]) + (X - x[0]) * (X - x[3]) + (X - x[1]) * (X - x[2]) + (X - x[0]) * (X - x[2]) + (X - x[0]) * (X - x[1]));
            
            Console.WriteLine("Производная с вторым порядком точности:");
            Console.Write($"{dyy[0]}\t");
            Console.WriteLine();
            ddyy.Clear();
            for (int i = 0; i < 1; i++)
            {
                dyy[i] = 2.0 * (((y[i + 2] - y[i + 1]) / (x[i + 2] - x[i + 1]) - (y[i + 1] - y[i]) / (x[i + 1] - x[i])) / (x[i + 2] - x[i])) +/**/2.0 * (((((y[i + 3] - y[i + 2]) / (x[i + 3] - x[i + 2]) - (y[i + 2] - y[i + 1]) / (x[i + 2] - x[i + 1])) / (x[i + 3] - x[i + 1])) - ((y[i + 2] - y[i + 1]) / (x[i + 2] - x[i + 1]) - (y[i + 1] - y[i]) / (x[i + 1] - x[i])) / (x[i + 2] - x[i])) / (x[i + 3] - x[i])) * ((X - x[i]) + (X - x[i + 1]) + (X - x[i + 2]))/**/+ 2.0 * ((((((y[i + 4] - y[i + 3]) / (x[i + 4] - x[i + 3]) - (y[i + 3] - y[i + 2]) / (x[i + 3] - x[i + 2])) / (x[i + 4] - x[i + 2])) - ((y[i + 3] - y[i + 2]) / (x[i + 3] - x[i + 2]) - (y[i + 2] - y[i+1]) / (x[i + 2] - x[i+1])) / (x[i + 3] - x[i+1])) / (x[i + 4] - x[i+1])) - ((((y[i + 3] - y[i + 2]) / (x[i + 3] - x[i + 2]) - (y[i + 2] - y[i+1]) / (x[i + 2] - x[i+1])) / (x[i + 3] - x[i+1])) - ((y[i + 2] - y[i + 1]) / (x[i + 2] - x[i + 1]) - (y[i + 1] - y[i]) / (x[i + 1] - x[i])) / (x[i + 2] - x[i]))/(x[i+3]-x[i]))/(x[i+4]-x[i])*((X-x[i])+(X-x[i+1])+(X-x[i+2])+(X-x[i+3]));
                
            }
            Console.WriteLine("Вторая производная в точке:");
            Console.Write($"{dyy[0]}\t");
            Console.ReadKey();
        }

    }
}
