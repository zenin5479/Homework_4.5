using LibraryFor1DArray;
using System;
using System.IO;

// Дано 3 одномерных массива A, B и C разного размера
// Для каждого из них найти требуемое значение, и затем использовать его для решения второй задачи
// Если найденные значения совпадают, вывести соответствующее сообщение (с указанием имён массивов с совпадающими значениями)
// Для обработки массивов, ввода и вывода использовать подпрограммы
// Иметь в виду, что искомых элементов в массиве(ах) может не быть
// Этот случай должен быть предусмотрен
// Быть внимательным при определении типа данных элементов массивов
// В том из массивов, в котором нет нулей, заменить отрицательные элементы их номером

namespace Homework_4._5
{
   internal class Program
   {
      static void Main(string[] args)
      {
         // Переводит (,) в (.)
         //System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

         string nameOne = "A";
         string nameTwo = "B";
         string nameThree = "C";

         int elementsOne = VariousMethods.NumberArrayElements(nameOne);
         int elementsTwo = VariousMethods.NumberArrayElements(nameTwo);
         int elementsThree = VariousMethods.NumberArrayElements(nameThree);

         string pathOne = Path.GetFullPath("a.txt");
         if (!File.Exists(pathOne))
         {
            Console.WriteLine("Ошибка при открытии файла для чтения. Файл не существует");
         }

         string pathTwo = Path.GetFullPath("b.txt");
         if (!File.Exists(pathTwo))
         {
            Console.WriteLine("Ошибка при открытии файла для чтения. Файл не существует");
         }

         string pathThree = Path.GetFullPath("c.txt");
         if (!File.Exists(pathThree))
         {
            Console.WriteLine("Ошибка при открытии файла для чтения. Файл не существует");
         }

         string pathFour = Path.GetFullPath("finish.txt");
         if (!File.Exists(pathFour))
         {
            Console.WriteLine("Ошибка при открытии файла для чтения. Файл не существует");
            File.Create(pathFour);
         }
         else
         {
            Console.WriteLine("Файл существует. Очищаем");
            // Очищаем содержимое файла
            // Вариант 1
            File.Create(pathFour).Close();
            // Вариант 2
            //File.WriteAllLines(pathFour, new string[0]);
            //File.WriteAllLines(pathFour, Array.Empty<string>());
            // Вариант 3
            //File.WriteAllText(pathFour, string.Empty);
            // Вариант 4
            //File.WriteAllBytes(pathFour, new byte[0]);
            //File.WriteAllBytes(pathFour, Array.Empty<byte>());
            // Вариант 5
            //FileStream fileStream = new FileStream(pathFour, FileMode.Truncate);
            //fileStream.Close();
            // Вариант 6
            //FileStream fileStream = new FileStream(pathFour, FileMode.Open);
            //fileStream.SetLength(0);
            //fileStream.Close();
         }

         double[] sourceOne = VariousMethods.VvodArray(pathOne, nameOne);
         double[] sourceTwo = VariousMethods.VvodArray(pathTwo, nameTwo);
         double[] sourceThree = VariousMethods.VvodArray(pathThree, nameThree);

         double[] searchOne = VariousMethods.InputArray(sourceOne, elementsOne, nameOne);
         double[] searchTwo = VariousMethods.InputArray(sourceTwo, elementsTwo, nameTwo);
         double[] searchThree = VariousMethods.InputArray(sourceThree, elementsThree, nameThree);

         bool flagOne = VariousMethods.FindZero(searchOne, nameOne);
         if (flagOne == false)
         {
            double[] replacingOne = VariousMethods.ReplacingZero(searchOne);
            string[] arrayOne = VariousMethods.VivodStringArray(replacingOne);
            VariousMethods.FileAppendString(arrayOne, pathFour);
         }

         bool flagTwo = VariousMethods.FindZero(searchTwo, nameTwo);
         if (flagTwo == false)
         {
            double[] replacingTwo = VariousMethods.ReplacingZero(searchTwo);
            string[] arrayTwo = VariousMethods.VivodStringArray(replacingTwo);
            VariousMethods.FileAppendString(arrayTwo, pathFour);
         }

         bool flagThree = VariousMethods.FindZero(searchThree, nameThree);
         if (flagThree == false)
         {
            double[] replacingThree = VariousMethods.ReplacingZero(searchThree);
            string[] arrayThree = VariousMethods.VivodStringArray(replacingThree);
            VariousMethods.FileAppendString(arrayThree, pathFour);
         }

         Console.ReadKey();
      }
   }
}