using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЧМ1._4
{
    public class Rotations
    {
        public bool Done { get; private set; }
        public Vector EigenValues { get; private set; }
        public Vector[] EigenVectors { get; private set; }
        public int Iterations { get; private set; }

        public Rotations(Matrix A, double eps, int iterations_count)
        {
            Done = false;

            int n = A.N;
            Matrix U = new Matrix(n), L = A;
            for (int i = 0; i < n; i++) U[i, i] = 1;

            for (Iterations = 0; Iterations < iterations_count; Iterations++)
            {
                //максимальный элемент
                int i0 = 0, j0 = 1;

                for (int j = 2; j < n; j++)
                    for (int i = 0; i < j; i++)
                        if (Math.Abs(L[i, j]) > Math.Abs(L[i0, j0]))
                        {
                            i0 = i;
                            j0 = j;
                        }

                //применяем преобразование
                Matrix Uk = Matrix.Rotation(0.5 * Math.Atan(2 * L[i0, j0] / (L[i0, i0] - L[j0, j0])), i0, j0, n);
                U = Uk * U;
                L = Uk.Transponent() * L * Uk;

                //условие выхода
                if (L.NormUpper() < eps)
                {
                    Done = true;

                    EigenValues = new Vector(n);
                    for (int i = 0; i < n; i++) EigenValues[i] = L[i, i];

                    EigenVectors = new Vector[n];
                    for (int i = 0; i < n; i++) EigenVectors[i] = U.GetCol(i);

                    break;
                }
            }
        }
    }
}
