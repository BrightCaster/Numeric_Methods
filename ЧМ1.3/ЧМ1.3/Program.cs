using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЧМ1._3
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
            Interations interations=null;
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
                    Vector B1 = new Vector(size);
                    B1.Random();
                    Console.WriteLine("Вектор В");
                    B1.Print();
                    Console.WriteLine("Полный вид системы");
                    PrintMatrixFull(A1, B1);
                    Console.Write("Введите точность:");
                    
                    try
                    {
                        eps = Convert.ToDouble(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Вы ввели неверный формат");
                    }

                    interations = new Interations(A1, B1, eps, 1000);
                    break;

                case "2":
                    Matrix A2 = new Matrix(4);
                    A2.VarVvod();
                    Console.WriteLine("Матрица А");
                    A2.PrintMatrix();
                    Vector B2 = new Vector(4);
                    B2.VarVvod();
                    Console.WriteLine("Вектор В");
                    B2.Print();
                    Console.WriteLine("Полный вид системы");
                    PrintMatrixFull(A2, B2);
                    Console.Write("Введите точность:");

                    try
                    {
                        eps = Convert.ToDouble(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Вы ввели неверный формат");
                    }

                    interations = new Interations(A2, B2, eps, 1000);
                    break;
                case "3":
                    Console.Write("Введите размер матрицы:");
                    size = Convert.ToInt32(Console.ReadLine());
                    Matrix A3 = new Matrix(size);
                    A3.Read();
                    Console.WriteLine("Матрица А");
                    A3.PrintMatrix();

                    Vector B3 = new Vector(size);
                    Console.WriteLine("Вводите элементы вектора B");
                    B3.Read();
                    Console.WriteLine("Вектор B");
                    B3.Print();
                    Console.WriteLine("Полный вид системы");
                    PrintMatrixFull(A3, B3);

                    Console.Write("Введите точность:");
                    
                    try
                    {
                        eps = Convert.ToDouble(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Вы ввели неверный формат");
                    }

                    interations = new Interations(A3, B3, eps, 1000);
                    break;
                    
            }

            Console.WriteLine("Норма матрицы альфа: " + interations.Norm);

            Console.WriteLine("Метод простых итераций:");
            if (interations.Try)
            {
                Console.WriteLine("Число итераций: " + interations.Iterations);
                Console.WriteLine("Решение:");
                interations.Reshenie.Print();
            }
            else
                Console.WriteLine("Требуемая точность не достигнута за 1000 итераций");

            Console.WriteLine("Метод Зейделя:");
            if (interations.zTry)
            {
                Console.WriteLine("Число итераций: " + interations.ZIterations);
                Console.WriteLine("Решение:");
                interations.ZReshenie.Print();
            }
            else
                Console.WriteLine("Требуемая точность не достигнута за 1000 итераций");
            
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
