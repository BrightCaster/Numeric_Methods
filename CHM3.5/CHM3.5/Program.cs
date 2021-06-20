using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHM3._5
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] X = new double[] { 1, 5 };
            double h1 = 1.0, h2 = 0.5;
            double[] x1 = new double[] { };
            double[] x2 = new double[] { };
            List<double> list = new List<double>();
            list.Add(X[0]);
            for (int i=0; ; i++)
            {
                
                list.Add(list.Last()+h1);
                if (list.Last() == X[1]) break;
            }
            x1 = list.ToArray();
            list.Clear();
            Console.Write($"x1");
            for (int i = 0;i<x1.Length ; i++)
            {
                Console.Write($"\t{x1[i]}");
            }
            list.Add(X[0]);
            for (int i = 0; ; i++)
            {

                list.Add(list.Last() + h2);
                if (list.Last() == X[1]) break;
            }
            x2 = list.ToArray();
            Console.WriteLine();
            Console.Write($"x2");
            for (int i = 0; i < x2.Length; i++)
            {
                Console.Write($"\t{x2[i]}");
            }
            double[] y1 = new double[x1.Length];
            for(int i = 0; i < y1.Length; i++)
            {
                y1[i] = y(x1[i]);
            }
            double[] y2 = new double[x2.Length];
            for (int i = 0; i < y2.Length; i++)
            {
                y2[i] = y(x2[i]);
            }
            double FFF = -0.16474;
            Console.WriteLine("\nМетод прямоугольников");
            double fP = FP(x1, h1);
            Console.WriteLine("\nОтвет:{0}",fP);
            Console.WriteLine("\nМетод трапеций");
            double fT = FT(x1, h1);
            Console.WriteLine("\nОтвет:{0}", fT);
            Console.WriteLine("\nМетод Симпсона");
            double fS = FS(y1, h1, x1);
            Console.WriteLine("\nОтвет:{0}", fS);
            Console.WriteLine("\nРунге для прямоугольников");
            double rungep = Runge(FP(x1, h1), FP(x2, h2), 2, h1, h2);
            Console.WriteLine("\nОтвет:{0}", rungep);
            Console.WriteLine("\nРунге для трапеций");
            double runget = Runge(FT(x1, h1), FT(x2, h2), 2, h1, h2);
            Console.WriteLine("\nОтвет:{0}", runget);
            Console.WriteLine("\nРунге для Симпсона");
            double runges = Runge(FS(y1, h1, x1), FS(y2, h2, x2), 4, h1, h2);
            Console.WriteLine("\nОтвет:{0}", runges);
            double[] h = { h1, h2 };
            double[][] x = { x1, x2 };
            double[][] yy = { y1, y2 };
            Console.WriteLine("Погрешность метода: ");
            for (int i = 0; i < h.Length; i++)
            {
                Console.Write($"Прямоугольника:\t{FFF - FP(x[i],h[i])}");
                Console.Write($"\tТрапеций:\t{FFF - FT(x[i], h[i])}");
                Console.Write($"\tСимпсона:\t{FFF - FS(yy[i], h[i], x[i])}");
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        static double y(double x)
        {
            double y = Math.Sqrt(x) / (4 + 3 * x);
            return y;
        }
        static double FP(double[] x, double h)
        {
            double Sum = 0;
            double sum = 0;
            double FP;
            double fp = sum * h; 
            //Console.Write($"\t{fp}");
            for (int i = 1; i < x.Length; i++)
            {
                Sum += (y((x[i-1] + x[i]) / 2));
                sum += (y((x[i-1] + x[i]) / 2));
                fp = sum * h;
                //Console.Write($"\t{fp}");
            }
            FP = Sum * h;
            return FP;
        }
        static double FT(double[] x, double h)
        {
            double Sum = 0;
            double sum = 0;
            double FT;
            double ft = sum * h;
            //Console.Write($"\t{ft}");
            for (int i = 1; i < x.Length; i++)
            {
                Sum += ((y(x[i]) + y(x[i - 1])) / 2);
                sum += ((y(x[i]) + y(x[i - 1])) / 2);
                ft = sum * h;
                //Console.Write($"\t{ft}");
            }
            FT = Sum * h;
            return FT;
        }
        static double FS(double[] y1, double h, double[] x)
        {
            double Sum = 0;
            double sum = 0;
            double FS;
            double fs = sum * h;
            //Console.Write($"\t{fs}");
            for (int i = 1; i < y1.Length; )
            {
                double Y = y(x[i]);
                Sum += (y1[i - 1] + 4.0 * Y + y1[i+1]) / 3.0;
                sum += (y1[i - 1] + 4.0 * Y + y1[i+1]) / 3.0;
                fs = sum*h;
                //Console.Write($"\t{fs}");
                i = i+2;
            }
            FS = Sum *h;
            return FS;
        }
        static double Runge(double Fh, double Fkh, int p,double h1,double h2)
        {
            double Runge =((Fh - Fkh) / (Math.Pow(h2/h1, p) - 1.0));
            return Runge;
        }

    }
}
