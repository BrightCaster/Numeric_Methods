using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЧМ1._4
{
    public class Matrix
    {
        private double[,] Values;

        public double this[int i, int j]
        {
            get { return Values[i, j]; }
            set { Values[i, j] = value; }
        }

        public int N { get; }

        public Matrix(int n)
        {
            Values = new double[n, n];
            N = n;
        }
        public void VarVvod()
        {
            Values[0, 0] = -7; Values[0, 1] = -9; Values[0, 2] = 1;
            Values[1, 0] = -9; Values[1, 1] = 7; Values[1, 2] = 2; 
            Values[2, 0] = 1; Values[2, 1] = 2; Values[2, 2] = 9;
        }
        public void Random()
        {
            Random random = new Random();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Values[i, j] = random.Next(0, 9);
                }
            }
        }
        public void Read()
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write($"Элемент {i},{j}:\t");
                    Values[i, j] = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine();
                }
            }
        }
        public void PrintMatrix()
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write($"\t{Values[i, j]}");
                }
                Console.WriteLine();
            }
        }
        public Vector GetCol(int j)
        {
            Vector v = new Vector(N);
            for (int i = 0; i < N; i++) v[i] = Values[i, j];
            return v;
        }

        public double Norm()
        {
            double sum = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    sum += Values[i, j] * Values[i, j];
                }
            }
            return Math.Sqrt(sum);
        }
        public double NormUpper()
        {
            double sum = 0;
            for (int j = 1; j < N; j++)
                for (int i = 0; i < j; i++)
                    sum += Values[i, j] * Values[i, j];
            return Math.Sqrt(sum);
        }
        public Matrix Transponent()
        {
            Matrix T = new Matrix(N);
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    T[i, j] = Values[j, i];
            return T;
        }
        public static Matrix Rotation(double angle, int i1, int i2, int n)
        {
            Matrix U = new Matrix(n);
            for (int i = 0; i < n; i++) U[i, i] = 1;

            U[i1, i1] = U[i2, i2] = Math.Cos(angle);
            U[i2, i1] = Math.Sin(angle);
            U[i1, i2] = -U[i2, i1];

            return U;
        }
        public static Matrix operator +(Matrix A, Matrix B)
        {
            Matrix AB = new Matrix(A.N);
            for (int i = 0; i < A.N; i++)
                for (int j = 0; j < A.N; j++)
                    AB[i, j] = A[i, j] + B[i, j];
            return AB;
        }

        public static Matrix operator *(Matrix A, Matrix B)
        {
            Matrix AB = new Matrix(A.N);
            for (int i = 0; i < A.N; i++)
                for (int j = 0; j < A.N; j++)
                    for (int k = 0; k < A.N; k++)
                        AB[i, j] += A[i, k] * B[k, j];
            return AB;
        }
        public static Vector operator *(Matrix A, Vector B)
        {
            Vector AB = new Vector(A.N);
            for (int i = 0; i < A.N; i++)
                for (int j = 0; j < A.N; j++)
                    AB[i] += A[i, j] * B[j];
            return AB;
        }
    }
}
