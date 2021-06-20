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
            double[,] massiv = new double[4, 4];
            massiv[0, 0] = 7;   massiv[0, 1] = 8;   massiv[0, 2] = 4;   massiv[0, 3] = -6;
            massiv[1, 0] = -1;  massiv[1, 1] = 6;   massiv[1, 2] = -2;  massiv[1, 3] = -6;
            massiv[2, 0] = 2;   massiv[2, 1] = 9;   massiv[2, 2] = 6;   massiv[2, 3] = -4;
            massiv[3, 0] = 5;   massiv[3, 1] = 9;   massiv[3, 2] = 1;   massiv[3, 3] = 4;
            double[] massivb = new double[4] { -126, -42, -115, -67 };
            double[,] L = new double[,] { };
            double[,] U = new double[,] { };
            double[] mass = new double[4];
            double[,] netmass = new double[,] { };
            Func.luDecomposition(massiv, 4, out L, out U);

            Console.WriteLine("Исходная матрица а и b");
            func.Print(massiv, massivb);

            Console.WriteLine("Матрица LU");
            func.Print(L, U);
            Console.WriteLine();

            double d = Func.Det(massiv, massivb);
            Console.WriteLine("Det(A): {0}",d);

            mass = Func.Solve(massiv,massivb);
            func.Print(mass, "Решение: ");
            Console.WriteLine();

            Console.WriteLine("Обратная матрица");
            netmass = Func.Minor(massiv,massivb);
            netmass = Func.Dop(netmass);
            netmass = Func.Transpoze(netmass);
            for (int i = 0; i < 4; i++)
            {
                for (int j = i; j < 4; j++)
                {
                    netmass[i, j] = netmass[i, j] / d;
                }
            }
            func.Print(netmass,4);
            
            Console.ReadKey();
        }
    }
    class Func
    {
        
        static public double[] Solve(double[,] massiv, double[] massivb)
        {
            int length = massivb.Length;
            double[,] l = new double[4, 4];
            double[,] u = new double[4, 4];
            luDecomposition(massiv, 4, out l, out u);
            double[] x = new double[4];
            double[] y = new double[4];

            double Sum(int i)
            {
                double rez = 0;
                for (int j = 0; j < length; j++)
                {
                    rez += l[i, j] * y[j];
                }
                return rez;
            }
            for (int i = 0; i < length; i++)
            {
                y[i] = massivb[i] - Sum(i);
            }
            double Sum_x(int i)
            {
                double rez = 0;
                for (int j = i; j < length; j++)
                {
                    rez += u[i, j] * x[j];
                }
                return rez;
            }
            for (int i = length-1; i != 0; i--)
            {
                x[i] = (y[i] - Sum_x(i)) / u[i, i];
            }
            return x;
        }
        
        static public double Det(double[,] massiv, double[] massivb)
        {
            double[,] L = new double[,] { };
            double[,] U = new double[,] { };
            luDecomposition(massiv, 4, out L, out U);
            double dU = 1;
            double dL = 1;
            for (int i = 0; i < massivb.Length; i++)
            {
                dU *= U[i, i];
            }
            for (int i = 0; i < massivb.Length; i++)
            {
                dL *= L[i, i];
            }
            double d = dL * dU;
            return d;
        }
        public void Print(double[,] massiv, double[] massivb)
        {
            for (int i = 0; i < massivb.Length; i++)
            {
                for (int j = 0; j < massivb.Length; j++)
                {
                    Console.Write($"\t{massiv[i,j]}");
                }
                Console.Write($"\t{massivb[i]}");
                Console.WriteLine();
            }
        }
        public void Print(double[,] massiv, double[,] massivb)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write($"\t{massiv[i, j]:f1}");
                }
                if (i == 1)
                {
                    Console.Write("  *");
                }
                for (int j = 0; j < 4; j++)
                {
                    Console.Write($"\t{massivb[i, j]:f1}");
                }
                
                Console.WriteLine();
            }
        }
        public void Print(double[] massiv, string s)
        {
            Console.WriteLine();

            Console.Write($"{s}");
            for (int i = 0; i < massiv.Length; i++)
            {
                Console.Write($"\t{massiv[i]:0.0}");
            }
        }
        public void Print(double[,] massiv, int length)
        {
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    Console.Write($"\t\t{massiv[i, j]:0.00}");
                }
                
                Console.WriteLine();
            }
        }
        static public void luDecomposition(double[,] mat, int n, out double[,] low, out double[,] upp)
        {
            double[,] lower = new double[n, n];
            double[,] upper = new double[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int k = i; k < n; k++)
                {
                    double sum = 0;
                    for (int j = 0; j < i; j++)
                        sum += (lower[i, j] * upper[j, k]);
                    upper[i, k] = mat[i, k] - sum;
                }

                for (int k = i; k < n; k++)
                {
                    if (i == k)
                        lower[i, i] = 1; // Диагональ как 1
                    else
                    {
                        double sum = 0;
                        for (int j = 0; j < i; j++)
                            sum += (lower[k, j] * upper[j, i]);
                        lower[k, i] = (mat[k, i] - sum) / upper[i, i];
                    }
                }
            }
            low = lower;
            upp = upper;
        }
        static public double[,] Minor(double[,] massiv, double[] massivb)
        {
            int length = massivb.Length;
            int x;
            int y;
            double[,] minor = new double[length, length];
            double[,] Matrixlow = new double[length - 1, length - 1];
            double[,] lminor = new double[length - 1, length - 1];
            double[,] uminor = new double[length - 1, length - 1];
            for (int i = 0; i < length; i++)
            {
                x = i;
                for (int j = 0; j < length; j++)
                {
                    y = j;

                    //Console.WriteLine($"Номер минора {i},{j}:\t{Matrix[i, j]}");

                    for (int s = 0; s < length; s++)
                    {
                        if (s == i) continue;
                        for (int k = 0; k < length; k++)
                        {
                            if (k == j) continue;
                            if (s > 0 && k > 0)
                            {
                                if (y < k)
                                {
                                    if (x > s)
                                    {
                                        Matrixlow[s, k - 1] = massiv[s, k];
                                        //Console.Write($"\t{Matrixlow[s, k - 1]}");
                                    }
                                    else
                                    {
                                        Matrixlow[s - 1, k - 1] = massiv[s, k];
                                        //Console.Write($"\t{Matrixlow[s - 1, k - 1]}");
                                    }

                                }
                                else
                                {
                                    if (x > s)
                                    {
                                        Matrixlow[s, k] = massiv[s, k];
                                        //Console.Write($"\t{Matrixlow[s, k - 1]}");
                                    }
                                    else
                                    {
                                        Matrixlow[s - 1, k] = massiv[s, k];
                                        //Console.Write($"\t{Matrixlow[s - 1, k]}");
                                    }

                                }
                            }
                            else if (s > 0)
                            {
                                if (x > s)
                                {
                                    Matrixlow[s, k] = massiv[s, k];
                                    //Console.Write($"\t{Matrixlow[s, k]}");
                                }
                                else
                                {
                                    Matrixlow[s - 1, k] = massiv[s, k];
                                    //Console.Write($"\t{Matrixlow[s - 1, k]}");
                                }
                            }
                            else if (k > 0)
                            {
                                if (y > k)
                                {
                                    Matrixlow[s, k] = massiv[s, k];
                                    //Console.Write($"\t{Matrixlow[s, k]}");
                                }
                                else
                                {
                                    Matrixlow[s, k - 1] = massiv[s, k];
                                    //Console.Write($"\t{Matrixlow[s, k - 1]}");
                                }
                            }
                            else if (s == 0 && k == 0)
                            {
                                Matrixlow[s, k] = massiv[s, k];
                                //Console.Write($"\t{Matrixlow[s, k]}");
                            }
                        }
                        //Console.WriteLine();
                    }
                    luDecomposition(Matrixlow, 3, out lminor, out uminor);
                    //Console.WriteLine("L * U");
                    //Print(lminor, uminor);
                    double dU = 1;
                    double dL = 1;
                    for (int s = 0; s < length - 1; s++)
                    {
                        dU *= uminor[s, s];
                    }
                    for (int s = 0; s < length - 1; s++)
                    {
                        dL *= lminor[s, s];
                    }
                    double det = dL * dU;
                    minor[i, j] = det;
                }
            }
            return minor;
        }
        static public double[,] Transpoze(double[,] minor)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = i; j < 4; j++)
                {
                    double t = minor[i, j];
                    minor[i, j] = minor[j, i];
                    minor[j, i] = t;
                }
            }
            return minor;
        }
        static public double[,] Dop(double[,] minor)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    minor[i, j] = minor[i, j] * Math.Pow((-1), i + j);
                }
            }
            return minor;
        }


    }
    
}
