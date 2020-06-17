using System;

namespace Dogs
{
    class Program
    {
        static void Main(string[] args)
        {
            var dog1 = new Dog()
            {
                Name = "Bruno",
                Color = "Black",
                Id = 3
            };

            var dog2 = new Dog()
            {
                Name = "Ralph",
                Color = "Brown"
            };

            var dog3 = new Dog()
            {
                Name = "Max",
                Color = "White",
                Id = 0
            };

            DogShelter.PrintAll();
            Console.WriteLine(Dog.Validate(dog1));
            Console.WriteLine(Dog.Validate(dog2));
            Console.WriteLine(Dog.Validate(dog3)); 
        }
    }
}
