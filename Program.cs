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

         string nameArrayOne = "A";
         string nameArrayTwo = "B";
         string nameArrayThree = "C";

         int elementsOne = ClassFor1DArray.NumberArrayElements(nameArrayOne);
         int elementsTwo = ClassFor1DArray.NumberArrayElements(nameArrayTwo);
         int elementsThree = ClassFor1DArray.NumberArrayElements(nameArrayThree);

         string filePathOne = Path.GetFullPath("a.txt");
         if (!File.Exists(filePathOne))
         {
            Console.WriteLine("Ошибка при открытии файла для чтения. Файл не существует");
         }

         string filePathTwo = Path.GetFullPath("b.txt");
         if (!File.Exists(filePathTwo))
         {
            Console.WriteLine("Ошибка при открытии файла для чтения. Файл не существует");
         }

         string filePathThree = Path.GetFullPath("c.txt");
         if (!File.Exists(filePathThree))
         {
            Console.WriteLine("Ошибка при открытии файла для чтения. Файл не существует");
         }

         double[] arrayDoubleOne = ClassFor1DArray.VvodArray(filePathOne, nameArrayOne);
         double[] arrayDoubleTwo = ClassFor1DArray.VvodArray(filePathTwo, nameArrayTwo);
         double[] arrayDoubleThree = ClassFor1DArray.VvodArray(filePathThree, nameArrayThree);

         double[] arraySearchOne = ClassFor1DArray.InputArray(arrayDoubleOne, elementsOne, nameArrayOne);
         double[] arraySearchTwo = ClassFor1DArray.InputArray(arrayDoubleTwo, elementsTwo, nameArrayTwo);
         double[] arraySearchThree = ClassFor1DArray.InputArray(arrayDoubleThree, elementsThree, nameArrayThree);

         int countOne = ClassFor1DArray.SearchingNullNumbers(arraySearchOne, nameArrayOne);
         int countTwo = ClassFor1DArray.SearchingNullNumbers(arraySearchTwo, nameArrayTwo);
         int countThree = ClassFor1DArray.SearchingNullNumbers(arraySearchThree, nameArrayThree);
         ClassFor1DArray.ComparisonValue(countOne, countTwo, countThree);

         Console.ReadKey();
      }

      public static void get(double value1, double value2)
      {
         // сравниваем оба значения double используя метод Equals(Double)
         bool status = value1.Equals(value2);
         // проверка статуса
         if (status)
         {
            Console.WriteLine("{0} равно {1}", value1, value2);
         }
      }
   }
}