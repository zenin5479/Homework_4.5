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
      static void Main()
      {
         // Переводит (,) в (.)
         //System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

         string nameOne = "A";
         string nameTwo = "B";
         string nameThree = "C";

         int elementsOne = MethodsForArray.NumberArrayElements(nameOne);
         int elementsTwo = MethodsForArray.NumberArrayElements(nameTwo);
         int elementsThree = MethodsForArray.NumberArrayElements(nameThree);

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

         double[] sourceOne = MethodsForArray.VvodArray(pathOne, nameOne);
         double[] sourceTwo = MethodsForArray.VvodArray(pathTwo, nameTwo);
         double[] sourceThree = MethodsForArray.VvodArray(pathThree, nameThree);

         double[] searchOne = MethodsForArray.InputArray(sourceOne, elementsOne, nameOne);
         double[] searchTwo = MethodsForArray.InputArray(sourceTwo, elementsTwo, nameTwo);
         double[] searchThree = MethodsForArray.InputArray(sourceThree, elementsThree, nameThree);

         bool flagOne = MethodsForArray.FindZero(searchOne, nameOne);
         if (flagOne == false)
         {
            double[] replacingOne = MethodsForArray.ReplacingZero(searchOne);
            string[] arrayOne = MethodsForArray.VivodStringArray(replacingOne);
            MethodsForArray.FileAppendString(arrayOne, pathFour);
         }

         bool flagTwo = MethodsForArray.FindZero(searchTwo, nameTwo);
         if (flagTwo == false)
         {
            double[] replacingTwo = MethodsForArray.ReplacingZero(searchTwo);
            string[] arrayTwo = MethodsForArray.VivodStringArray(replacingTwo);
            MethodsForArray.FileAppendString(arrayTwo, pathFour);
         }

         bool flagThree = MethodsForArray.FindZero(searchThree, nameThree);
         if (flagThree == false)
         {
            double[] replacingThree = MethodsForArray.ReplacingZero(searchThree);
            string[] arrayThree = MethodsForArray.VivodStringArray(replacingThree);
            MethodsForArray.FileAppendString(arrayThree, pathFour);
         }

         Console.ReadKey();
      }
   }
}