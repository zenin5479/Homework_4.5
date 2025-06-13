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

         double[] arrayDoubleOne = ClassFor1DArray.VvodArray(pathOne, nameOne);
         double[] arrayDoubleTwo = ClassFor1DArray.VvodArray(pathTwo, nameTwo);
         double[] arrayDoubleThree = ClassFor1DArray.VvodArray(pathThree, nameThree);

         double[] arraySearchOne = ClassFor1DArray.InputArray(arrayDoubleOne, elementsOne, nameOne);
         double[] arraySearchTwo = ClassFor1DArray.InputArray(arrayDoubleTwo, elementsTwo, nameTwo);
         double[] arraySearchThree = ClassFor1DArray.InputArray(arrayDoubleThree, elementsThree, nameThree);

         bool flagArrayOne = ClassFor1DArray.FindZero(arraySearchOne, nameOne);
         if (flagArrayOne == false)
         {
            double[] replacingArrayOne = ClassFor1DArray.ReplacingZero(arraySearchOne);
            string[] arrayOne = ClassFor1DArray.VivodStringArray(replacingArrayOne);
            ClassFor1DArray.FileAppendString(arrayOne, pathFour);
         }

         bool flagArrayTwo = ClassFor1DArray.FindZero(arraySearchTwo, nameTwo);
         if (flagArrayTwo == false)
         {
            double[] replacingArrayTwo = ClassFor1DArray.ReplacingZero(arraySearchTwo);
            string[] arrayTwo = ClassFor1DArray.VivodStringArray(replacingArrayTwo);
            ClassFor1DArray.FileAppendString(arrayTwo, pathFour);
         }

         bool flagArrayThree = ClassFor1DArray.FindZero(arraySearchThree, nameThree);
         if (flagArrayThree == false)
         {
            double[] replacingArrayThree = ClassFor1DArray.ReplacingZero(arraySearchThree);
            string[] arrayThree = ClassFor1DArray.VivodStringArray(replacingArrayThree);
            ClassFor1DArray.FileAppendString(arrayThree, pathFour);
         }

         Console.ReadKey();
      }
   }
}