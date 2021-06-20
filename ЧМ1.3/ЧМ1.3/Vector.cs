using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЧМ1._3
{
    class Vector
    {
        private double[] Values;

        public double this[int i]
        {
            get { return Values[i]; }
            set { Values[i] = value; }
        }

        public int N { get; }

        public Vector(int n)
        {
            Values = new double[n];
            N = n;
        }
        public void VarVvod()
        {
            Values[0] = -99;    Values[1] = 0;  Values[2] = 67; Values[3] = 58;
        }
        public void Random()
        {
            Random random = new Random();
            for (int i = 0; i < N; i++)
            {
                Values[i] = random.Next(0, 9);
            }
        }
        public void Read()
        {
            for (int i = 0; i < N; i++)
            {
                Console.Write($"Элемент {i}:\t");

                Values[i] = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine();
            }
        }
        public void Print()
        {
            for (int i = 0; i < N; i++)
            {
                Console.Write($"\t{Values[i]}");
            }
            Console.WriteLine();
        }
        public double Norm()
        {
            double sum = 0;
            for (int i = 0; i < N; i++)
            {
                sum += Values[i] * Values[i];
            }
            return Math.Sqrt(sum);
        }
        public static Vector operator *(double a, Vector b)
        {
            Vector v = new Vector(b.N);
            for (int i = 0; i < b.N; i++)
            {
                v[i] = a * b[i];
            }
            return v;
        }
        public static Vector operator +(Vector a, Vector b)
        {
            Vector v = new Vector(b.N);
            for (int i = 0; i < b.N; i++)
            {
                v[i] = a[i] + b[i];
            }
            return v;
        }
    }
}
