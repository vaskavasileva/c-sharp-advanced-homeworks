using System;
using System.Collections.Generic;
using System.Text;

namespace Dogs
{
    public class Dog
    {
        public Dog()
        {
            DogShelter.ListOfDogs.Add(this);
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }

        public void Bark()
        {
            Console.WriteLine("Bark bark");
        }

        public static string Validate(Dog dog)
        {
            bool hasAll = false;
            
            
            if (dog.Id != 0 
                && !string.IsNullOrEmpty(dog.Name) 
                && !string.IsNullOrEmpty(dog.Color) 
                && dog.Name.ToCharArray().Length >= 2 
                && dog.Id > 0)
            {
                hasAll = true;
            }

            if (hasAll)
            {
                return "The dog has all 3 properties.";
            }

            else
            {
                return "The dog doesn't have all 3 properties.";
            }
        }

    }
}
