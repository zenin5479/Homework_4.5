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

         int elementsOne = ClassFor1DArray.NumberArrayElements(nameOne);
         int elementsTwo = ClassFor1DArray.NumberArrayElements(nameTwo);
         int elementsThree = ClassFor1DArray.NumberArrayElements(nameThree);

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

         double[] sourceOne = ClassFor1DArray.VvodArray(pathOne, nameOne);
         double[] sourceTwo = ClassFor1DArray.VvodArray(pathTwo, nameTwo);
         double[] sourceThree = ClassFor1DArray.VvodArray(pathThree, nameThree);

         double[] searchOne = ClassFor1DArray.InputArray(sourceOne, elementsOne, nameOne);
         double[] searchTwo = ClassFor1DArray.InputArray(sourceTwo, elementsTwo, nameTwo);
         double[] searchThree = ClassFor1DArray.InputArray(sourceThree, elementsThree, nameThree);

         bool flagOne = ClassFor1DArray.FindZero(searchOne, nameOne);
         if (flagOne == false)
         {
            double[] replacingOne = ClassFor1DArray.ReplacingZero(searchOne);
            string[] arrayOne = ClassFor1DArray.VivodStringArray(replacingOne);
            ClassFor1DArray.FileAppendString(arrayOne, pathFour);
         }

         bool flagTwo = ClassFor1DArray.FindZero(searchTwo, nameTwo);
         if (flagTwo == false)
         {
            double[] replacingTwo = ClassFor1DArray.ReplacingZero(searchTwo);
            string[] arrayTwo = ClassFor1DArray.VivodStringArray(replacingTwo);
            ClassFor1DArray.FileAppendString(arrayTwo, pathFour);
         }

         bool flagThree = ClassFor1DArray.FindZero(searchThree, nameThree);
         if (flagThree == false)
         {
            double[] replacingThree = ClassFor1DArray.ReplacingZero(searchThree);
            string[] arrayThree = ClassFor1DArray.VivodStringArray(replacingThree);
            ClassFor1DArray.FileAppendString(arrayThree, pathFour);
         }

         Console.ReadKey();
      }
   }
}