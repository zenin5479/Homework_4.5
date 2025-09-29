using System;
using System.IO;
using System.Text;

namespace Homework_4._5
{
   internal class MethodsForArray
   {
      public static int NumberArrayElements(string nameArray)
      {
         int n;
         do
         {
            Console.WriteLine("Введите количество элементов массива {0}", nameArray);
            int.TryParse(Console.ReadLine(), out n);
            //n = Convert.ToInt32(Console.ReadLine());
            if (n <= 0 || n > 20)
            {
               Console.WriteLine("Введено не верное значение");
            }
         } while (n <= 0 || n > 20);

         return n;
      }

      public static double[] VvodArray(string path, string nameArray)
      {
         string stroka = null;
         FileStream filestream = File.Open(path, FileMode.Open, FileAccess.Read);
         StreamReader streamReader = new StreamReader(filestream);
         while (streamReader.Peek() >= 0)
         {
            stroka = streamReader.ReadLine();
            //Console.WriteLine(stroka);
         }

         streamReader.Close();
         //Console.WriteLine();
         Console.WriteLine("Исходный строковый массив {0}", nameArray);
         Console.WriteLine(stroka);

         // Определение количества столбцов в строке разделением строки на подстроки по пробелу
         // Символ пробела
         char symbolSpace = ' ';
         // Счетчик символов
         int symbolСount = 0;
         // Количество столбцов в строке
         int сolumn = 0;
         if (stroka != null)
         {
            while (symbolСount < stroka.Length)
            {
               if (symbolSpace == stroka[symbolСount])
               {
                  сolumn++;
               }

               if (symbolСount == stroka.Length - 1)
               {
                  сolumn++;
               }

               symbolСount++;
            }

            //Console.WriteLine("Количество столбцов {0}", сolumn);
         }

         // Разделение строки на подстроки по пробелу и конвертация подстрок в double
         Console.WriteLine("Массив вещественных чисел {0}", nameArray);
         // Одномерный массив вещественных чисел
         double[] arrayDouble = new double[сolumn];
         // Построитель строк
         StringBuilder stringModified = new StringBuilder();
         // Счетчик символов обнуляем
         symbolСount = 0;
         // Количество столбцов в строке обнуляем
         сolumn = 0;
         if (stroka != null)
         {
            while (symbolСount < stroka.Length)
            {
               if (symbolSpace != stroka[symbolСount])
               {
                  stringModified.Append(stroka[symbolСount]);
               }
               else
               {
                  string subLine = stringModified.ToString();
                  arrayDouble[сolumn] = Convert.ToDouble(subLine);
                  Console.Write(arrayDouble[сolumn] + " ");
                  stringModified.Clear();
                  сolumn++;
               }

               if (symbolСount == stroka.Length - 1)
               {
                  string subLine = stringModified.ToString();
                  arrayDouble[сolumn] = Convert.ToDouble(subLine);
                  Console.Write(arrayDouble[сolumn]);
                  stringModified.Clear();
                  сolumn++;
               }

               symbolСount++;
            }
         }

         Console.WriteLine();
         return arrayDouble;
      }

      public static double[] InputArray(double[] inputArray, int n, string nameArray)
      {
         Console.WriteLine("Массив вещественных чисел {0} для проведения поиска", nameArray);
         double[] outputArray = new double[n];
         int i = 0;
         while (i < n)
         {
            outputArray[i] = inputArray[i];
            //Console.Write("{0:f2} ", outputArray[i]);
            //Console.Write("{0:f} ", outputArray[i]);
            Console.Write("{0} ", outputArray[i]);
            i++;
         }

         Console.WriteLine();
         return outputArray;
      }

      public static bool FindZero(double[] inputArray, string nameArray)
      {
         double numbercomparison = 0;
         bool flag = false;
         int i = 0;
         while (i < inputArray.Length && flag == false)
         {
            // Сравниваем значения double используя метод CompareTo(Double) 
            if (inputArray[i].CompareTo(numbercomparison) == 0)
            {
               flag = true;
            }

            // Сравниваем значения double используя метод Equals(Double)
            //if (inputArray[i].Equals(numbercomparison))
            //{
            //   flag = true;
            //}

            // Сравниваем значения double используя оператор равенства ==
            //if (inputArray[i] == 0)
            //{
            //   flag = true;
            //}

            i++;
         }

         if (flag)
         {
            Console.WriteLine("В массиве {0} имеется элемент равный нулю", nameArray);
         }
         else
         {
            Console.WriteLine("В массиве {0} отсутствует элемент равный нулю", nameArray);
         }

         return flag;
      }

      public static double[] ReplacingZero(double[] inputArray)
      {
         double numbercomparison = 0;
         int i = 0;
         while (i < inputArray.Length)
         {
            // Сравниваем значения double используя метод CompareTo(Double) 
            //if (inputArray[i].CompareTo(numbercomparison) < 0)
            //{
            //   inputArray[i] = i;
            //}

            // Сравниваем значения double используя оператор равенства ==
            if (inputArray[i] < numbercomparison)
            {
               inputArray[i] = i;
            }

            i++;
         }

         return inputArray;
      }

      public static void FileAppendString(string[] stringArray, string filePath)
      {
         // Запись массива строк в файл
         Console.WriteLine("Запись массива строк в файл");
         File.AppendAllLines(filePath, stringArray);
      }

      public static string[] VivodStringArray(double[] inputArray)
      {
         // Объединение одномерного массива максимальных значений строк double[]
         // в одномерный массив строк string[] для записи в файл (в одну строку массива)
         Console.WriteLine("Одномерный массив строк");
         StringBuilder stringModified = new StringBuilder();
         int row = 0;
         while (row < inputArray.Length)
         {
            if (row != inputArray.Length - 1)
            {
               stringModified.Append(inputArray[row] + " ");
            }
            else
            {
               stringModified.Append(inputArray[row]);
            }

            row++;
         }

         Console.WriteLine(stringModified);
         string[] stringArray = { stringModified.ToString() };
         return stringArray;
      }
   }
}