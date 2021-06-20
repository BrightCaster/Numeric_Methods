using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHM3._2
{
    public static class Program
    {
        public static double X = 0.1;
        public static double[] x = new double[] { -0.4, -0.1, 0.2, 0.5, 0.8 };
        public static double[] f = new double[] { 1.5823, 1.5710, 1.5694, 1.5472, 1.4435 };
        public static double[] H = h1(x);
        public static double[,] matrix = Matrix(H);
        public static double[] vector = Vector(f, H);
        public static double[] c1 = Solve(matrix, vector);
        static double[] fr(double[] c1)
        {
            double[] c = new double[x.Length];
            for (int i = 0; i < c.Length; i++)
            {
                if (i == 0) c[i] = 0;
                else if (i == 1) c[i] = c1[c1.Length - 1];
                else c[i] = c1[i - 2];

            }
            return c;
        }
        public static double[] c = fr(c1);
        public static double[] A = a(f);
        public static double[] B = b(f, H, c);
        public static double[] D = d(H, c);

        static void Main(string[] args)
        {
            double X = 0.1;
            //double[] x = new double[] { 0, 1.0, 2.0, 3.0, 4.0 };
            //double[] f = new double[] { 0, 1.8415, 2.9093, 3.1411, 3.2432 };

            double[] x = new double[] { -0.4, -0.1, 0.2, 0.5, 0.8 };
            double[] f = new double[] { 1.5823, 1.5710, 1.5694, 1.5472, 1.4435 };
            double[] H = h1(x);
            double[,] matrix = Matrix(H);
            double[] vector = Vector(f, H);
            double[] c1 = Solve(matrix, vector);
            double[] c = new double[x.Length];
            for(int i = 0; i < c.Length; i++)
            {
                if (i == 0) c[i] = 0;
                else if (i == 1) c[i] = c1[c1.Length-1];
                else c[i] = c1[i - 2];
                
            }
            double[] A = a(f);
            double[] B = b(f, H, c);
            double[] D = d(H, c);
            double[] fAnswer = F1(A, B, c, D, x, X);
            for (int i = 0; i < x.Length; i++)
            {
                Console.Write($"\t{fAnswer[i]}");
            }
            Console.WriteLine();
            Console.WriteLine(F(A,B,c,D,x,X));

            Form1 form1 = new Form1();
            form1.ShowDialog();
            Console.ReadKey();
        }
        public static double[] F1(double[] a, double[] b, double[] c, double[] d, double[] x, double X)
        {
            double[] F = new double[x.Length];
            for (int i = 1; i < x.Length; i++)
            {
                F[i] = a[i] + b[i] * (X - x[i - 1]) + c[i] * Math.Pow((X - x[i - 1]), 2) + d[i] * Math.Pow((X - x[i - 1]), 3);
                    
            }
            return F;
        }
        static double F(double[] a, double[] b, double[] c, double[] d, double[] x, double X)
        {
            double F = 0;
            for(int i = 1; i < x.Length; i++)
            {
                if((x[i-1]<=X) && (X <= x[i]))
                {
                    F = a[i] + b[i] * (X - x[i - 1]) + c[i] * (X - x[i - 1]) * (X - x[i - 1]) + d[i] * (X - x[i - 1]) * (X - x[i - 1]) * (X - x[i - 1]);
                    break;
                }
            }
            return F;
        }
        static double[] h1(double[] x)
        {
            double[] h = new double[5];
            for (int i = 1; i < x.Length; i++)
            {
                h[i] = x[i] - x[i - 1];
            }
            return h;
        }

        static double[,] Matrix(double[] h)
        {
            double[,] matrix = new double[4,4];
            matrix[0, 0] = 2.0 * (h[1] + h[2]);   matrix[0, 1] = h[2];
            matrix[1, 0] = h[2];    matrix[1, 1] = 2.0 * (h[2] + h[3]);   matrix[1, 2] = h[3];
            matrix[2, 1] = h[3];    matrix[2, 2] = 2.0 * (h[3] + h[4]);
            return matrix;
        }
        static double[] Vector(double[] f, double[] h)
        {
            double[] vector = new double[3];
            vector[0] = 3.0 * ((f[2] - f[1]) / h[2] - (f[1] - f[0]) / h[1]);
            vector[1] = 3.0 * ((f[3] - f[2]) / h[3] - (f[2] - f[1]) / h[2]);
            vector[2] = 3.0 * ((f[4] - f[3]) / h[4] - (f[3] - f[2]) / h[3]);
            return vector;
        }
        static double[] a(double[] f)
        {
            double[] a = new double[5];
            for (int i = 1; i < a.Length; i++)
            {
                a[i] = f[i - 1];
            }
            return a;
        }
        static double[] b(double[] f, double[] h, double[] c)
        {
            double[] b = new double[5];
            for(int i = 1; i < 4; i++)
            {
                b[i] = (f[i] - f[i - 1]) / h[i] - (1.0 / 3.0 * h[i] * (c[i + 1] + 2.0 * c[i]));
            }
            b[4] = (f[4] - f[3]) / h[4] - (2.0 / 3.0 * h[4] * c[4]);
            return b;
        }
        static double[] d(double[] h, double[] c)
        {
            double[] d = new double[5];
            for(int i = 1; i < d.Length-1; i++)
            {
                d[i] = (c[i + 1] - c[i]) / (3.0 * h[i]);
            }
            d[d.Length-1] = -(c[d.Length-1] / (3.0 * h[d.Length-1]));
            return d;
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
        static public double[] Solve(double[,] massiv, double[] massivb)
        {
            int length = massivb.Length;
            double[,] l = new double[4, 4];
            double[,] u = new double[4, 4];
            luDecomposition(massiv, 3, out l, out u);
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
            for (int i = length - 1; i != -1; i--)
            {
                x[i] = (y[i] - Sum_x(i)) / u[i, i];
            }
            return x;
        }





    }
}
