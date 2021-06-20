using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЧМ1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Func func = new Func();
            int[,] massiv = new int[5, 5];
            /*0*/            massiv[0, 0] = -6;     massiv[0, 1] = 6;
            /*1*/                                   massiv[1, 0] = 2;       massiv[1, 1] = 10;       massiv[1, 2] = -7;
            /*2*/                                                           massiv[2, 1] = -8;       massiv[2, 2] = 18;      massiv[2, 3] = 9;
            /*3*/                                                                                    massiv[3, 2] = 6;       massiv[3, 3] = -17;        massiv[3, 4] = -6;
            /*4*/                                                                                                            massiv[4, 3] = 9;          massiv[4, 4] = 14;
            int[] massivb = new int[5] { 30, -31, 108, -114, 124 };
            double[] x = new double[5];

            func.Print(massiv, massivb);
            Console.WriteLine();

            x = func.Otvet(massiv, massivb);
            func.Print(x);

            Console.ReadKey();
        }

    }
    class Func
    {
        public void Print(int[,] massiv, int[] massivb)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write($"\t{massiv[i, j]}");
                }
                Console.Write($"\t{massivb[i]}");
                Console.WriteLine();
            }
        }
        public double[] Otvet(int[,] massiv, int[] massivb)
        {
            double[] P = new double[massivb.Length], Q = new double[massivb.Length];
            P[0] = -massiv[0, 1] / massiv[0, 0];
            Q[0] = massivb[0] / massiv[0, 0];
            for (int i = 1; i < P.Length - 1; i++)
            {
                P[i] = (-massiv[i, i + 1]) / (massiv[i, i] + massiv[i, i - 1] * P[i - 1]);
                Q[i] = (massivb[i] - massiv[i, i - 1] * Q[i - 1]) / (massiv[i, i] + massiv[i, i - 1] * P[i - 1]);
            }
            int j = 4;
            P[j] = 0;
            Q[j] = (massivb[j] - massiv[j, j - 1] * Q[j - 1]) / (massiv[j, j] + massiv[j, j - 1] * P[j - 1]);

            double[] x = new double[massivb.Length];
            x[j] = Q[j];
            while (j != 0)
            {
                j--;
                x[j] = P[j] * x[j + 1] + Q[j];
            }
            return x;
        }
        public void Print(double[] x)
        {
            Console.Write("Ответ:");
            for (int j = 0; j < 5; j++)
            {
                Console.Write($"\t{x[j]}");
            }
        }
    }

}
