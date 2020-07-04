using System;
using System.IO;

namespace Calculations
{
    class Program
    {
        public static string appPath = Directory.GetCurrentDirectory();
        public static string folderPath = Path.Combine(appPath, "Exercise");
        public static string filePath = Path.Combine(folderPath, "calculations.txt");

        static void Main(string[] args)
        {
            int num1;
            int num2;
            Console.WriteLine("Please enter a number: ");
            while (true)
            {
                var input = Console.ReadLine();

                bool isNumber = int.TryParse(input, out num1);
                if (isNumber)
                {
                    break;
                }
                Console.WriteLine("Please enter a valid number.");
            }

            Console.WriteLine("Please enter a second number: ");
            while (true)
            {
                var input = Console.ReadLine();

                bool isNumber = int.TryParse(input, out num2);
                if (isNumber)
                {
                    break;
                }
                Console.WriteLine("Please enter a valid number.");
            }

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
            var result = Calculate(num1, num2);
            Console.WriteLine(result);
            WriteInFile(result, filePath);
        }

        public static string Calculate(int num1, int num2)
        {
            return $"{num1} + {num2} = {num1+num2}"; 
        }

        public static void WriteInFile(string text, string path)
        {
            using (var sw = new StreamWriter(path,true))
            {
                sw.Write(text);
                sw.WriteLine(DateTime.Now);
            }

        }
    }
}
