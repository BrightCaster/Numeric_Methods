using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms.DataVisualization.Charting;

namespace CHM3._3
{
    static class Program
    {
        //public static double[] x = new double[] { -0.7, -0.4, -0.1, 0.2, 0.5, 0.8 };
        //public static double[] y = new double[] { 1.6462, 1.5823, 1.571, 1.5694, 1.5472, 1.4435 };
        public static double[] x = new double[] { 0.0, 1.7, 3.4, 5.1, 6.8, 8.5 };
        public static double[] y = new double[] { 0.0, 3.0038, 8.2439, 11.3583, 13.4077, 11.415 };
        public static double[,] matrix1 = Matrix1(x);
        public static double[] vector1 = Vector1(y, x, matrix1);
        public static double[] a1 = Solve(matrix1, vector1, 2);
        public static double[] f1xx=f11(x,a1);
        static double[] f11(double[] x, double[] a)
        {
            double[] f11 = new double[x.Length];
            for(int i = 0; i < x.Length; i++)
            {
                f11[i] = f1x(x[i], a);
            }
            return f11;
        }
        public static double[,] matrix2 = Matrix2(x);
        public static double[] vector2 = Vector2(y, x, matrix2);
        public static double[] a2 = Solve(matrix2, vector2, 3);
        public static double[] f2xx = f22(x, a2);
        static double[] f22(double[] x, double[] a)
        {
            double[] f22 = new double[x.Length];
            for (int i = 0; i < x.Length; i++)
            {
                f22[i] = f2x(x[i], a);
            }
            return f22;
        }
        static void Main(string[] args)
        {
            double[] x = new double[] { 0.0, 1.7, 3.4, 5.1, 6.8, 8.5 };
            double[] y = new double[] { 0.0, 3.0038, 8.2439, 11.3583, 13.4077, 11.415 };
            double[,] matrix1 = Matrix1(x);
            double[] vector1 = Vector1(y,x,matrix1);
            double[] a1 = Solve(matrix1, vector1, 2);
            Console.Write($"F1 = {F1(x,y,a1)}");
            double[,] matrix2 = Matrix2(x);
            double[] vector2 = Vector2(y, x, matrix2);
            double[] a2 = Solve(matrix2, vector2, 3);
            Console.Write($"\nF2 = {F2(x, y, a2)}");
            CHM3._3.Form1 form1 = new Form1();

            form1.ShowDialog();
            Console.ReadKey();


        }
        static double F1(double[] x, double[] y, double[] a)
        {
            double F = 0;
            for(int i = 0; i < 6; i++)
            {
                F += ((f1x(x[i], a) - y[i]) * (f1x(x[i], a) - y[i]));
            }
            return F;
        }
        static double F2(double[] x, double[] y, double[] a)
        {
            double F = 0;
            for (int i = 0; i < 6; i++)
            {
                F += ((f2x(x[i], a) - y[i]) * (f2x(x[i], a) - y[i]));
            }
            return F;
        }
        static double f1x(double x, double[] a)
        {
            double f1x = a[0] + a[1] * x;
            return f1x;
        }
        static double f2x(double x, double[] a)
        {
            double f1x = a[0] + a[1] * x + a[2] * x * x;
            return f1x;
        }
        static double[,] Matrix1(double[] x)
        {
            double[] xx = new double[x.Length];
            for(int i = 0; i < x.Length; i++)
            {
                xx[i] = Math.Pow(x[i], 2);
            }
            double[,] matrix = new double[2, 2];
            matrix[0, 0] = x.Length;    matrix[0, 1] = x.Sum();
            matrix[1, 0] = x.Sum(); matrix[1, 1] = xx.Sum();
            return matrix;
        }
        static double[] Vector1(double[] y, double[] x, double[,] matrix)
        {
            double[] xy = new double[x.Length];
            for(int i = 0; i < x.Length; i++)
            {
                xy[i] = y[i] * x[i];
            }
            double[] b = new double[matrix.Length / 2];
            b[0] = y.Sum();
            b[1] = xy.Sum();
            return b;
        }
        static public double[] Solve(double[,] massiv, double[] massivb, int n)
        {
            int length = massivb.Length;
            double[,] l = new double[4, 4];
            double[,] u = new double[4, 4];
            luDecomposition(massiv, n, out l, out u);
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
        static double[,] Matrix2(double[] x)
        {
            double[] xx = new double[x.Length];
            double[] xxx = new double[x.Length];
            double[] xxxx = new double[x.Length];

            for (int i = 0; i < x.Length; i++)
            {
                xx[i] = Math.Pow(x[i], 2);
            }
            for (int i = 0; i < x.Length; i++)
            {
                xxx[i] = Math.Pow(x[i], 3);
            }
            for (int i = 0; i < x.Length; i++)
            {
                xxxx[i] = Math.Pow(x[i], 4);
            }
            double[,] matrix = new double[3, 3];
            matrix[0, 0] = x.Length; matrix[0, 1] = x.Sum();    matrix[0, 2] = xx.Sum();
            matrix[1, 0] = x.Sum();  matrix[1, 1] = xx.Sum();    matrix[1, 2] = xxx.Sum();
            matrix[2, 0] = xx.Sum(); matrix[2, 1] = xxx.Sum();  matrix[2, 2] = xxxx.Sum();
            
            return matrix;
        }
        static double[] Vector2(double[] y, double[] x, double[,] matrix)
        {
            double[] xy = new double[x.Length];
            double[] xxy = new double[x.Length];
            for (int i = 0; i < x.Length; i++)
            {
                xy[i] = y[i] * x[i];
            }
            for (int i = 0; i < x.Length; i++)
            {
                xxy[i] = y[i] * x[i] * x[i];
            }
            double[] b = new double[3];
            b[0] = y.Sum();
            b[1] = xy.Sum();
            b[2] = xxy.Sum();
            return b;
        }
    }
}
