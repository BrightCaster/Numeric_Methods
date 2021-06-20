using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHM2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write($"Введите точность вычисления: ");
            double eps = Convert.ToDouble(Console.ReadLine());
            bool quit = true;
            double[] x1 = new double[10000];
            double x = 0;
            double[] x2 = new double[10000];
            double y = 0;
            x1[0] = 1;
            x2[0] = 1.25;
            Console.WriteLine("\nМетод Ньютона");
            for(int i=1; quit != false ; i++) 
            {
                x1[i] = x1[i - 1] - (detA1(eps, x1[i - 1], x2[i - 1]) / detJ(eps, x1[i - 1], x2[i - 1]));
                x = x1[i];

                x2[i] = x2[i - 1] - (detA2(eps, x1[i - 1], x2[i - 1]) / detJ(eps, x1[i - 1], x2[i - 1]));
                y = x2[i];
                if(x>0 &&y>0)
                    if ((Math.Abs(x1[i] - x1[i - 1]) <= eps)&&((Math.Abs(x2[i] - x2[i - 1]) <= eps))) quit = false;
            }
            
            Console.WriteLine($"x={x}\ty={y}\n");

            Console.WriteLine("Метод Простых итераций");
            x1 = new double[10000];
            x2 = new double[10000];
            x1[0] = 1;
            x2[0] = 1.25;
            quit = true;
            double q = Maxfi(eps, x1[0], x2[0]);
            for (int i = 1; quit != false; i++)
            {
                x1[i] = fi1(x1[i - 1], x2[i - 1]);
                x = x1[i];
                x2[i] = fi2(x1[i - 1], x2[i - 1]);
                y = x2[i];
                if (x > 0 && y > 0)
                    if ((q / (1 - q) * Math.Abs(x1[i] - x1[i - 1]) <= eps) && (q / (1 - q) * Math.Abs(x2[i] - x2[i - 1]) <= eps)) quit = false;
            }
            Console.WriteLine($"x={x}\ty={y}\n");
            Console.ReadKey();
            
        }
        static double detJ(double eps, double x1, double x2)
        {
            double[] dx1 = Dx1(eps, x1, x2);
            double[] dx2 = Dx2(eps, x1, x2);
            double df1x1 = dx1[0];  double df1x2 = dx2[0];
            double df2x1 = dx1[1];  double df2x2 = dx2[1];
            double J = df1x1 * df2x2 - df2x1 * df1x2;
            return J;
        }
        static double detA1(double eps, double x1, double x2)
        {
            double[] dx1 = Dx1(eps, x1, x2);
            double[] dx2 = Dx2(eps, x1, x2);
            double df1x1 = dx1[0]; double df1x2 = dx2[0];
            double df2x1 = dx1[1]; double df2x2 = dx2[1];
            double f11 = f1(x1,x2);
            double f22 = f2(x1,x2);
            double A1 = f11 * df2x2 - f22 * df1x2;
            return A1;
        }

        static double detA2(double eps, double x1, double x2)
        {
            double[] dx1 = Dx1(eps, x1, x2);
            double[] dx2 = Dx2(eps, x1, x2);
            double df1x1 = dx1[0]; double df1x2 = dx2[0];
            double df2x1 = dx1[1]; double df2x2 = dx2[1];
            double f11 = f1(x1, x2);
            double f22 = f2(x1, x2);
            double A2 = df1x1 * f22 - df2x1 * f11;
            return A2;
        }

        static double f1(double x1,double x2)
        {
            double f1 = x1 * x1 - 2 * Math.Log10(x2) - 1;
            return f1;
        }
        static double f2(double x1, double x2)
        {
            double f2 = x1 * x1 - 2 * x1 * x2 + 2;
            return f2;
        }
        static double[] Dx1(double eps, double x1, double x2)
        {
            double dy1, dy2;
            double dx = eps;
            dy1 = (f1(x1 + dx, x2) - f1(x1, x2)) / dx;
            dy2 = (f2(x1 + dx, x2) - f2(x1, x2)) / dx;
            double[] dy = new double[] { dy1, dy2 };
            return dy;
        }
        static double[] Dx2(double eps, double x1, double x2)
        {
            double dy1, dy2;
            double dx = eps;
            dy1 = (f1(x1, x2 + dx) - f1(x1, x2)) / dx;
            dy2 = (f2(x1, x2 + dx) - f2(x1, x2)) / dx;
            double[] dy = new double[] { dy1, dy2 };
            return dy;
        }
        static double fi1(double x1,double x2)
        {
            double fi1 = Math.Sqrt(2*Math.Log10(x2)+1);
            return fi1;
        }
        static double fi2(double x1, double x2)
        {
            double fi2 = (2 + x1 * x1) / (2 * x1);
            return fi2;
        }
        static double[] Dx1fi(double eps, double x1, double x2)
        {
            double dy1, dy2;
            double dx = eps;
            dy1 = (fi1(x1 + dx, x2) - fi1(x1, x2)) / dx;
            dy2 = (fi2(x1 + dx, x2) - fi2(x1, x2)) / dx;
            double[] dy = new double[] { dy1, dy2 };
            return dy;
        }
        static double[] Dx2fi(double eps, double x1, double x2)
        {
            double dy1, dy2;
            double dx = eps;
            dy1 = (fi1(x1, x2 + dx) - fi1(x1, x2)) / dx;
            dy2 = (fi2(x1, x2 + dx) - fi2(x1, x2)) / dx;
            double[] dy = new double[] { dy1, dy2 };
            return dy;
        }
        static double Maxfi(double eps, double x1, double x2)
        {
            double[] dx1 = Dx1fi(eps, x1, x2);
            double[] dx2 = Dx2fi(eps, x1, x2);
            double dfi1x1 = dx1[0]; double dfi1x2 = dx2[0];
            double dfi2x1 = dx1[1]; double dfi2x2 = dx2[1];
            double Maxfi = Math.Max(Math.Abs(dfi1x1)+Math.Abs(dfi1x2), Math.Abs(dfi2x1) + Math.Abs(dfi2x2));
            return Maxfi;
        }
    }
}
