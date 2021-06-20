using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHM3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] aX = new double[] { -0.4, -0.1, 0.2, 0.5 };
            double[] bX = new double[] { -0.4, 0, 0.2, 0.5 };
            double X = 0.1;
            Console.WriteLine("Метод Лагранжа");
            Console.WriteLine($"Значения чисел а):{Lagrange(aX, X)} и погрешность равна: {f(X) - Lagrange(aX, X)}");
            Console.WriteLine($"Значения чисел б):{Lagrange(bX, X)} и погрешность равна: {f(X) - Lagrange(bX, X)}");
            Console.WriteLine("Метод Ньютона");
            Console.WriteLine($"Значения чисел а):{Newton(aX, X)} и погрешность равна: {f(X) - Newton(aX, X)}");
            Console.WriteLine($"Значения чисел б):{Newton(bX, X)} и погрешность равна: {f(X) - Newton(bX, X)}");
            Console.WriteLine("f(x) = {0}",f(X));
            Console.ReadKey();
        }

        static double f(double x)
        {
            double f = Math.Acos(x) + x;
            return f;
        }

        static double Lagrange(double[] x, double X)
        {
            double Sum = 0;
            for (int i = 0; i < x.Length; i++)
            {
                double Prois = 1;
                for (int j = 0; j < x.Length; j++)
                {
                    if (i!=j)
                        Prois *= (X - x[j]) / (x[i] - x[j]);
                }
                Sum += f(x[i]) * Prois;
            }
            return Sum;
        }
        static double Newton(double[] x, double X)
        {
            double Sum = 0, summ = 0;
            double Prois = 1, prois = 1;
            for (int i = 0; i < x.Length; i++)
            {
                Prois = 1;
                if (i != 0)
                {
                    for (int j = 0; j < i; j++)
                    {
                        Prois *= (X - x[j]);
                    }
                }
                summ = 0;
                for (int j = 0; j < i+1; j++)
                {
                    prois = 1;
                    for (int k = 0; k < i+1; k++)
                    {
                        if (k != j)
                        {
                            if (x[j] - x[k] == 0) continue;
                            else
                                prois *= (x[j] - x[k]);
                            
                        }
                    }
                    summ += (f(x[j]) / prois);
                }
                Sum += summ * Prois;
            }
            return Sum;
        }
    }
}
