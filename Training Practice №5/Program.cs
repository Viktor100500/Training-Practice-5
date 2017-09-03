using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Practice__5
{
    class Program
    {
        static void PrintMenu(string[] items) // Печать меню 
        {
            int i;
            int positionX = 3, positionY = 4;

            // Программа вывода меню 
            //Начальный вывод пунктов меню.
            for (i = 0; i < items.Length; i++)
            {
                Console.CursorLeft = positionX;
                Console.CursorTop = positionY + i;
                Console.ForegroundColor = ConsoleColor.Gray; Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(items[i]);
            }
        }

        static int ShowMenu(string[] items) // Функция работы меню 
        {
            int currentIndex = 0, previousIndex = 0, i;
            int positionX = 3, positionY = 4;
            bool itemSelected = false;

            // Программа вывода меню 
            //Начальный вывод пунктов меню.
            for (i = 0; i < items.Length; i++)
            {
                Console.CursorLeft = positionX;
                Console.CursorTop = positionY + i;
                Console.ForegroundColor = ConsoleColor.Gray; Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(items[i]);
            }

            do
            {
                // Вывод предыдущего активного пункта основным цветом.
                Console.CursorLeft = positionX;
                Console.CursorTop = positionY + previousIndex;
                Console.ForegroundColor = ConsoleColor.Gray; Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(items[previousIndex]);


                //Вывод активного пункта.
                Console.CursorLeft = positionX;
                Console.CursorTop = positionY + currentIndex;
                Console.ForegroundColor = ConsoleColor.Black; Console.BackgroundColor = ConsoleColor.Gray;
                Console.Write(items[currentIndex]);

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                previousIndex = currentIndex;
                switch (keyInfo.Key)
                {
                    case ConsoleKey.DownArrow:
                        currentIndex++;
                        break;
                    case ConsoleKey.UpArrow:
                        currentIndex--;
                        break;
                    case ConsoleKey.Enter:
                        itemSelected = true;
                        break;
                }

                if (currentIndex == items.Length)
                    currentIndex = items.Length - 1;
                else if (currentIndex < 0)
                    currentIndex = 0;
            }
            while (!itemSelected);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray; Console.BackgroundColor = ConsoleColor.Black;
            return currentIndex;
        }

        static void Main(string[] args) // Точка входа в приложение 
        {
            while (1 > 0)
            {
                Console.Clear();
                Console.WriteLine("Учебная практика №5, Власов Виктор");
                Console.WriteLine("ЗАДАЧА №399 Задачи по программированию. Квадратные матрицы порядка 9");

                double[,] Work = new double[8, 8];
                Work = VvodMassiva2();
                PrintMassiv(Work);
                NewMatrix(Work);
            }
        }

        public static void PrintMassiv(double[,] a) // Функция вывода двумерной действительной матрицы 
        {
            Console.CursorTop = Console.CursorTop + 1;
            Console.WriteLine("Текущая матрица:");
            int i, j;
            for (i = 0; i < a.GetLength(0); i++)
            {
                for (j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write(a[i, j] + "  ");
                }
                Console.WriteLine();
            }

        }

        public static void PrintMassiv(int[,] a) // Функция вывода двумерной целой матрицы
        {
            Console.CursorTop = Console.CursorTop + 1;
            Console.WriteLine("Результат:");
            int i, j;
            for (i = 0; i < a.GetLength(0); i++)
            {
                for (j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write(a[i, j] + "  ");
                }
                Console.WriteLine();
            }

        }

        public static double[,] VvodMassiva2() // Функция ввода двумерного матрицы 
        {
            bool ok;
            int kstrok = 9, kstolb = 9; // переменные
            int positionY = Console.CursorTop + 1;
            Console.CursorTop = positionY;

            string[] items = { "a) Заполнить матрицу рандомными числами", "б) Заполнить матрицу вручную" };

            double[,] a = new double[kstrok, kstolb]; // объявим матрицу

            switch (ShowMenu(items))
            {
                case 0:
                    int m, n; // переменные
                    Random S = new Random();
                    // заполнение матрицы случайными элементами
                    for (m = 0; m < kstrok; m++)
                    {
                        for (n = 0; n < kstolb; n++)
                        {
                            a[m, n] = S.Next(-100, 100) + S.Next(-99,99)*0.01;
                        }
                    }
                    Console.WriteLine();
                    break;

                case 1:
                    Console.WriteLine("Введите элементы матрицы:");
                    for (m = 0; m < kstrok; m++)
                    {
                        for (n = 0; n < kstolb; n++)
                        {
                            ok = false;
                            do
                            {
                                ok = Double.TryParse(Console.ReadLine(), out a[m, n]);
                                if (!ok) { Console.WriteLine("Неверный формат элемента. Введите целое число"); ok = false; }
                            } while (!ok);
                        }
                    }
                    break;
            }
            return a;
        }

        public static void NewMatrix(double[,] a) // Функция конвертации матрицы в новую
        {
            int i, j;
            int[,] NewMatrix = new int[9, 9];
            for (i = 0; i < a.GetLength(0); i++)
            {
                for (j = 0; j < a.GetLength(1); j++)
                {
                    if (a[i, j] > a[i, i]) { NewMatrix[i, j] = 1; }
                    else { NewMatrix[i, j] = 0; }
                }
            }
            PrintMassiv(NewMatrix);
            Console.WriteLine("Нажмите любую кнопку для нового запуска");
            Console.ReadLine();
        }
    }
}
