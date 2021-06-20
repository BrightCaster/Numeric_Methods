using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЧМ1._4
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
            double eps = 0;
            Rotations rotations = null;
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
                    for (int i = 1; i < size; i++)
                        for (int j = 0; j < i; j++)
                            if (A1[i, j] != A1[j, i])
                            {
                                Console.WriteLine("Матрица не симметрична");
                                Console.Read();
                                return;
                            }
                    Console.Write("Введите точность:");

                    try
                    {
                        eps = Convert.ToDouble(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Вы ввели неверный формат");
                    }
                    rotations = new Rotations(A1, eps, 1000);
                    if (rotations.Done)
                    {
                        Console.WriteLine("Число итераций: " + rotations.Iterations);

                        Console.WriteLine("Собственные значения:");
                        rotations.EigenValues.WriteToConsole();

                        Console.WriteLine("Собственные векторы:");
                        for (int i = 0; i < size; i++)
                        {
                            Console.Write($"u{i + 1} = ");
                            rotations.EigenVectors[i].WriteInBrackets();
                        }
                    }
                    else
                        Console.WriteLine("Требуемая точность не достигнута за 1000 итераций");
                    break;

                case "2":
                    Matrix A2 = new Matrix(3);
                    A2.VarVvod();
                    Console.WriteLine("Матрица А");
                    A2.PrintMatrix();
                    for (int i = 1; i < 3; i++)
                        for (int j = 0; j < i; j++)
                            if (A2[i, j] != A2[j, i])
                            {
                                Console.WriteLine("Матрица не симметрична");
                                Console.Read();
                                return;
                            }
                    Console.Write("Введите точность:");

                    try
                    {
                        eps = Convert.ToDouble(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Вы ввели неверный формат");
                    }
                    rotations = new Rotations(A2, eps, 1000);
                    if (rotations.Done)
                    {
                        Console.WriteLine("Число итераций: " + rotations.Iterations);

                        Console.WriteLine("Собственные значения:");
                        rotations.EigenValues.WriteToConsole();

                        Console.WriteLine("Собственные векторы:");
                        for (int i = 0; i < 3; i++)
                        {
                            Console.Write($"u{i + 1} = ");
                            rotations.EigenVectors[i].WriteInBrackets();
                        }
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
                    for (int i = 1; i < size; i++)
                        for (int j = 0; j < i; j++)
                            if (A3[i, j] != A3[j, i])
                            {
                                Console.WriteLine("Матрица не симметрична");
                                Console.Read();
                                return;
                            }

                    Console.Write("Введите точность:");

                    try
                    {
                        eps = Convert.ToDouble(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Вы ввели неверный формат");
                    }
                    rotations = new Rotations(A3, eps, 1000);
                    if (rotations.Done)
                    {
                        Console.WriteLine("Число итераций: " + rotations.Iterations);

                        Console.WriteLine("Собственные значения:");
                        rotations.EigenValues.WriteToConsole();

                        Console.WriteLine("Собственные векторы:");
                        for (int i = 0; i < size; i++)
                        {
                            Console.Write($"u{i + 1} = ");
                            rotations.EigenVectors[i].WriteInBrackets();
                        }
                    }
                    else
                        Console.WriteLine("Требуемая точность не достигнута за 1000 итераций");
                    break;

            }
            
            Console.ReadKey();
        }
        
    }
}
