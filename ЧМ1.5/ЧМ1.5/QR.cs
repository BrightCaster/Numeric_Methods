using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЧМ1._5
{
    public  class QR
    {
        public bool Finish { get; private set; }
        public int Iterations { get; private set; }
        public string[] EigenValues { get; private set; }

        public QR(Matrix A, double eps, int iterations_count)
        {
            Finish = false;

            for (Iterations = 0; Iterations < iterations_count; Iterations++)
            {
                A = DoQR(A);
                
                if (Dones(A, eps))
                {
                    Finish = true;
                    A.PrintMatrix();

                    //вычисляем собственные значения
                    int n = A.N;
                    EigenValues = eigenValues(A, eps, n);
                    break;
                }
                
            }
        }
        private string[] eigenValues(Matrix A, double eps, int n)
        {
            EigenValues = new string[n];
            for (int i = 0; i < n; i++)
            {
                if (i < n - 1 && Math.Abs(A[i + 1, i]) > eps)
                {
                    double D = A[i, i] * A[i, i] - 2 * A[i, i + 1] * A[i, i + 1] +
                        A[i + 1, i + 1] * A[i + 1, i + 1] + 4 * A[i, i + 1] * A[i + 1, i];

                    if (D < 0)
                    {
                        double re = (A[i, i] + A[i + 1, i + 1]) * 0.5;
                        double im = Math.Sqrt(-D) * 0.5;

                        EigenValues[i] = re + " + " + im + "i";
                        EigenValues[i + 1] = re + " - " + im + "i";
                    }
                    
                    else
                    {
                        double mid = (A[i, i] + A[i + 1, i + 1]) * 0.5;
                        double delta = Math.Sqrt(D) * 0.5;

                        EigenValues[i] = (mid + delta).ToString();
                        EigenValues[i + 1] = (mid - delta).ToString();
                    }
                    i++;
                }
                else
                    EigenValues[i] = A[i, i].ToString();
            }
            return EigenValues;
        }
        private Matrix H(Matrix A, int k)
        {
            int n = A.N;
            Vector v = new Vector(n);
            if (A[k, k] > 0) v[k] = A[k, k] + A.GetCol(k).Norm();
            else v[k] = A[k, k] - A.GetCol(k).Norm(); 
            
            for (int i = k + 1; i < n; i++) v[i] = A[i, k];
            double koeff = 2.0 / v.Norm2();
            
            Matrix Hk = new Matrix(n);

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    if (i == j) Hk[i, j] = 1 - koeff * v[i] * v[j];
                    else Hk[i, j] = -koeff * v[i] * v[j];
                }
            return Hk;
        }
        
        public Matrix DoQR(Matrix A)
        {
            int n = A.N;
            Matrix Q = null, R = null;

            for (int i = 0; i < n - 1; i++)
            {
                Matrix Hk = H(A, i);

                if (i == 0)
                {
                    Q = Hk;
                    R = Hk * A;
                }
                else
                {
                    Q *= Hk;
                    R = Hk * R;
                }
            }

            return R * Q;
        }
        
        private bool Dones(Matrix A, double eps)
        {
            int n = A.N;

            double lowDiag = 0;
            for (int i = 2; i < n; i++)
                for (int j = 0; j < i - 1; j++)
                    lowDiag += A[i, j] * A[i, j];

            if (Math.Sqrt(lowDiag) > eps)
                return false;
            
            for (int i = 0; i < n - 2; i++)
            {
                if (Math.Abs(A[i + 1, i]) > eps)
                {
                    if (Math.Abs(A[i + 2, i + 1]) > eps)
                        return false;
                    i++;
                }
            }
            return true;
        }
    }
}
