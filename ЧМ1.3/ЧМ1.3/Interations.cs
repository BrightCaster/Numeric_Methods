using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЧМ1._3
{
    class Interations
    {
        public double Norm { get; }
        public int N { get; }

        public bool Try { get; }
        public Vector Reshenie { get; }
        public int Iterations { get; }

        public bool zTry { get; }
        public Vector ZReshenie { get; }
        public int ZIterations { get; }

        public Interations(Matrix A, Vector B, double eps, int count)
        {
          
            
            N = B.N;
            Matrix I = new Matrix(N);
            Matrix T = new Matrix(N);
            for (int i = 0; i < N; i++)
            {
                T[i, i] = -1 / A[i, i];
                I[i, i] = 1;
            }

            Matrix Alpha = I + T * A;
            Vector Beta = (-1) * (T * B);

            Norm = Alpha.Norm();

            double koeff = 1;
            if (Norm < 1) koeff = Norm / (1 - Norm);


            Try = false;
            Vector x = new Vector(N), New_X;
            
            for (Iterations = 0; Iterations < count; Iterations++)
            {
                New_X = Alpha * x + Beta;

                if (koeff * (New_X + (-1) * x).Norm() < eps)
                {
                    Try = true;
                    Reshenie = New_X;
                    break;
                }

                x = New_X;
            }
            zTry = false;
            x = new Vector(N);

            for (ZIterations = 0; ZIterations < count; ZIterations++)
            {
                New_X = new Vector(N);

                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        New_X[i] += Alpha[i, j] * New_X[j];
                    }
                    for (int j = i; j < N; j++)
                    {
                        New_X[i] += Alpha[i, j] * x[j];
                    }
                    New_X[i] += Beta[i];
                }

                if (koeff * (New_X + (-1) * x).Norm() < eps)
                {
                    zTry = true;
                    ZReshenie = New_X;
                    break;
                }
                x = New_X;
            }
        }
    }
}
