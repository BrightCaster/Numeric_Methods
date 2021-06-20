using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHM2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Тут 2 значения корня");
            Console.Write($"Введите значение точности: ");
            double eps =Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Метод Ньютона");
            double[] x = new double[1000];
            x[0] = 1;
            bool quit = true;
            double x1 = 0, x2 = 0;
            while (quit)
            {
                x[0] = x[0] - eps;
                if (f(x[0]) * D2(eps, x[0]) > 0)
                {
                    for (int i = 1;x[i]!=-1 ; i++)
                    {
                        
                        x[i] = x[i - 1] - (f(x[i - 1]) / D(eps, x[i - 1]));
                        Console.Write($"{x[i]}\t");
                        x1 = x[i];
                        if (Math.Abs(x[i] - x[i - 1]) < eps) break;
                    }
                    quit = false;
                    
                }
            }
            Console.WriteLine();
            quit = true;
            x = new double[1000];
            x[0] = -1;
            while (quit)
            {
                x[0] = x[0] + eps;
                if (f(x[0]) * D2(eps, x[0]) < 0)
                {
                    for (int i = 1; ; i++)
                    {

                        x[i] = x[i - 1] + (f(x[i - 1]) / D(eps, x[i - 1]));
                        Console.Write($"{x[i]}\t");
                        x2 = x[i];
                        if (Math.Abs(x[i] - x[i - 1]) < eps) break;
                    }
                    quit = false;

                }
            }
            Console.WriteLine("\nx1={0}\tx2={1}",x1,x2);
            Console.WriteLine("Метод простой итерации");
            quit = true;
            x = new double[1000];
            x[0] = 1;

            for (int i = 1;x[i]!=0 ; i++)
            {
                x[i] = Dfi(eps,x[i-1]);
                double q = x[i];
                Console.Write($"{x[i]}\t");
                x1 = x[i];
                if (Math.Abs(x[i] - x[i - 1])*q/(1-q) <= eps) break;
            }
            quit = true;
            x = new double[1000];
            x[0] = -1;

            for (int i = 1; x[i] != 0; i++)
            {
                x[i] = Dfi(eps, x[i - 1]);
                double q = x[i];
                Console.Write($"{x[i]}\t");
                x2 = x[i];
                if (Math.Abs(x[i] - x[i - 1]) * q / (1 - q) <= eps) break;
            }
            Console.WriteLine("\nx1={0}\tx2={1}", x1, x2);

            Console.ReadKey();

        }
        static double D(double eps, double x)//первая производная
        {
            double dx = eps;
            double dy = (f(x + dx) - f(x)) / dx;
            return dy;
        }
        static double D2(double eps, double x)//вторая производная
        {
            double dx = eps;
            double dy2 = (f(x - dx) - 2 * f(x) + f(x + dx))/dx*dx;
            return dy2;
        }
        static double f(double x)
        {
            double f = Math.Tan(x) - 5 * x * x + 1;
            return f;
        }
        static double fi(double x)
        {
            double fi = Math.Sqrt((1-Math.Tan(x))/5);
            return fi;
        }
        static double Dfi(double eps, double x)//первая производная
        {
            double dx = eps;
            double dy = (fi(x + dx) - fi(x)) / dx;
            return dy;
        }
    }
}
