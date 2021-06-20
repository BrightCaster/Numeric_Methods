using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHM4._1
{
    class Program
    {
        static void Main(string[] args)
        {
            double h = 0.1;
            double xFirst = 2, xLast = 3;
            double[] x = new double[11];
            int q = 0;
            while (true)
            {
                
                x[q] = xFirst + q * h;
                if(x[q] == xLast) break;
                q++;
            }
            q = 0;
            
            
            

            Console.ReadKey();
        }
        static double Fx(double x, double y)
        {

        }
        static double Fxx(double x, double y, double z)
        {

        }
        static double FTochnoeReshenie(double x)
        {
            double y = Math.Pow(Math.Abs(x), 3 / 2);
            return y;
        }
        static double FD1(double x)
        {
            double dx = 0.001;
            double fdx = ((FTochnoeReshenie(x) + dx) - FTochnoeReshenie(x)) / dx;
            return fdx;
        }
        static double FD2(double x)
        {
            double dx = 0.001;
            double fdx = ((FD1(x) + dx) - FD1(x)) / dx;
            return fdx;
        }
    }
}
