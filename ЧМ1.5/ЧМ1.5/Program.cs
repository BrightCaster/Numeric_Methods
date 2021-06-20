using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЧМ1._5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Ввод случайной матрицы A и вектора B\n" +
                "2. Ввод текущей матрицы из варианта\n" +
                "3. Ручное заполнение");
            string key = Console.ReadLine();
            int size;
            Vector B;
            double eps = 0;
            QR qr = null;
            switch (key)
            {
                case "1":
                    Random random = new Random();
                    Console.Write("Введите размер матрицы:");
                    size = Convert.ToInt32(Console.ReadLine());
                    Matrix A1 = new Matrix(size);
                    A1.Random();
                    Console.WriteLine("Матрица А");
                    A1.PrintMatrix();

                    Console.Write("Введите точность:");

                    try
                    {
                        eps = Convert.ToDouble(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Вы ввели неверный формат");
                    }
                    qr = new QR(A1, eps, 1000);
                    if (qr.Finish)
                    {
                        Console.WriteLine("Число итераций: " + qr.Iterations);

                        Console.WriteLine("Собственные значения:");
                        for (int i = 0; i < size; i++)
                            Console.WriteLine($"lambda{i + 1} =\t{qr.EigenValues[i]}");
                    }
                    else
                        Console.WriteLine("Требуемая точность не достигнута за 1000 итераций");

                    break;

                case "2":
                    Matrix A2 = new Matrix(3);
                    A2.VarVvod();
                    Console.WriteLine("Матрица А");
                    A2.PrintMatrix();

                    Console.Write("Введите точность:");

                    try
                    {
                        eps = Convert.ToDouble(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Вы ввели неверный формат");
                    }

                    qr = new QR(A2, eps, 1000);
                    if (qr.Finish)
                    {
                        Console.WriteLine("Число итераций: " + qr.Iterations);

                        Console.WriteLine("Собственные значения:");
                        for (int i = 0; i < 3; i++)
                            Console.WriteLine($"lambda{i + 1} =\t{qr.EigenValues[i]}");
                        
                    }
                    else
                        Console.WriteLine("Требуемая точность не достигнута за 1000 итераций");

                    break;
                case "3":
                    Console.Write("Введите размер матрицы:");
                    size = Convert.ToInt32(Console.ReadLine());
                    Matrix A3 = new Matrix(size);
                    A3.Read();
                    Console.WriteLine("Матрица А");
                    A3.PrintMatrix();
                    

                    Console.Write("Введите точность:");

                    try
                    {
                        eps = Convert.ToDouble(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Вы ввели неверный формат");
                    }
                    qr = new QR(A3, eps, 1000);
                    if (qr.Finish)
                    {
                        Console.WriteLine("Число итераций: " + qr.Iterations);

                        Console.WriteLine("Собственные значения:");
                        for (int i = 0; i < size; i++)
                            Console.WriteLine($"lambda{i + 1} =\t{qr.EigenValues[i]}");
                    }
                    else
                        Console.WriteLine("Требуемая точность не достигнута за 1000 итераций");

                    break;

            }

           
            Console.ReadKey();
        }
        public static void PrintMatrixFull(Matrix A, Vector B)
        {
            for (int i = 0; i < A.N; i++)
            {
                for (int j = 0; j < A.N; j++)
                {
                    Console.Write($"\t{A[i, j]}");
                }
                Console.WriteLine($"\t|\t{B[i]}");
            }
        }
    }
}
