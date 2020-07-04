using DogsJson.Entities;
using System;
using Newtonsoft.Json;
using System.IO;

namespace DogsJson
{
    class Program
    {
        static void Main(string[] args)
        {
            var appPath = Directory.GetCurrentDirectory();
            var filePath = Path.Combine(appPath, "myJson.json");

            if (!File.Exists(filePath))
                File.Create(filePath).Close();

            bool newDog = true;
            while (newDog)
            {
                var myDog = new Dog();
                Console.WriteLine("Please enter the name of your dog.");
                myDog.Name = Console.ReadLine();

                int age;

                while (true)
                {
                    Console.WriteLine("Please enter the age of your dog.");
                    bool isDogAge = int.TryParse(Console.ReadLine(), out age);
                    if (isDogAge)
                    {
                        if (age >= 0 && age < 25)
                        {
                            break;
                        }
                        Console.WriteLine("Not a valid age, try again.");

                    }
                    Console.WriteLine("Please enter a number for your dogs age.");

                }

                myDog.Age = age;
                Console.WriteLine("Please enter the color of your dog:");
                myDog.Color = Console.ReadLine();

                

                var jsonDog = JsonConvert.SerializeObject(myDog);

                using (var sw = new StreamWriter(filePath, true))
                {
                    sw.Write(jsonDog);
                }

                Console.WriteLine("Do you want to enter another dog? Enter 1 for yes or 2 for no.");
                int answer;
                while (true)
                {
                    int.TryParse(Console.ReadLine(), out answer);
                    if (answer == 1)
                    {
                        break;
                    }
                    else if (answer == 2)
                    {
                        newDog = false;
                        break;
                    }
                    Console.WriteLine("Please choose 1 or 2.");

                }

            }

            using (var sr = new StreamReader(filePath))
            {
                Console.WriteLine(sr.ReadToEnd()); 
            }

        }
    }
}
