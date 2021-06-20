using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЧМ1._3
{
    class Matrix
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
            Values[0, 0] = 10;  Values[0, 1] = -1;  Values[0, 2] = -2;  Values[0, 3] = 5;
            Values[1, 0] = 4;   Values[1, 1] = 28;  Values[1, 2] = 7;   Values[1, 3] = 9;
            Values[2, 0] = 6;   Values[2, 1] = 5;   Values[2, 2] = -23; Values[2, 3] = 4;
            Values[3, 0] = 1;   Values[3, 1] = 4;   Values[3, 2] = 5;   Values[3, 3] = -15;
        }
        public void Random()
        {
            Random random = new Random();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Values[i, j] = random.Next(0,9);
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
