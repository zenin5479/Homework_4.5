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

         string filePathFour = Path.GetFullPath("finish.txt");
         if (!File.Exists(filePathFour))
         {
            Console.WriteLine("Ошибка при открытии файла для чтения. Файл не существует");
            File.Create(filePathFour);
         }
         else
         {
            Console.WriteLine("Файл существует. Очищаем");
            // Очищаем содержимое файла
            // Вариант 1
            //File.Create(filePathFour).Close();
            // Вариант 2
            //File.WriteAllLines(filePathFour, new string[0]);
            File.WriteAllLines(filePathFour, Array.Empty<string>());
            // Вариант 3
            //File.WriteAllText(filePathFour, string.Empty);
            // Вариант 4
            //File.WriteAllBytes(filePathFour, new byte[0]);
            //File.WriteAllBytes(filePathFour, Array.Empty<byte>());
            // Вариант 5
            //FileStream fileStream = new FileStream(filePathFour, FileMode.Truncate);
            //fileStream.Close();
            // Вариант 6
            //FileStream fileStream = new FileStream(filePathFour, FileMode.Open);
            //fileStream.SetLength(0);
            //fileStream.Close();
         }

         double[] arrayDoubleOne = ClassFor1DArray.VvodArray(filePathOne, nameArrayOne);
         double[] arrayDoubleTwo = ClassFor1DArray.VvodArray(filePathTwo, nameArrayTwo);
         double[] arrayDoubleThree = ClassFor1DArray.VvodArray(filePathThree, nameArrayThree);

         double[] arraySearchOne = ClassFor1DArray.InputArray(arrayDoubleOne, elementsOne, nameArrayOne);
         double[] arraySearchTwo = ClassFor1DArray.InputArray(arrayDoubleTwo, elementsTwo, nameArrayTwo);
         double[] arraySearchThree = ClassFor1DArray.InputArray(arrayDoubleThree, elementsThree, nameArrayThree);

         bool flagArrayOne = ClassFor1DArray.FindZero(arraySearchOne, nameArrayOne);
         if (flagArrayOne == false)
         {
            double[] replacingArrayOne = ClassFor1DArray.ReplacingZero(arraySearchOne);
            string[] arrayOne = ClassFor1DArray.VivodStringArray(replacingArrayOne);
            ClassFor1DArray.FileAppendString(arrayOne, filePathFour);
         }

         bool flagArrayTwo = ClassFor1DArray.FindZero(arraySearchTwo, nameArrayTwo);
         if (flagArrayTwo == false)
         {
            double[] replacingArrayTwo = ClassFor1DArray.ReplacingZero(arraySearchTwo);
            string[] arrayTwo = ClassFor1DArray.VivodStringArray(replacingArrayTwo);
            ClassFor1DArray.FileAppendString(arrayTwo, filePathFour);
         }

         //if (fla == false)
         //{
         //   zamenanol(a, na); +
         //   FILE* fp_finisha = fopen("finish.txt", "w");
         //   if (fp_finisha == nullptr)
         //   {
         //      printf("Ошибка при открытии файла для записи\n");
         //   }
         //   vivod_vect(a, na, fp_finisha); +
         //   fclose(fp_finisha);
         //}

         Console.ReadKey();
      }
   }
}