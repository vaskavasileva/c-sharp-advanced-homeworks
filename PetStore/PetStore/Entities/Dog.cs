using PetStore.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.Entities
{
    public class Dog : Pet
    {
        public Dog()
        {
            Type = PetType.Dog;
        }
        public bool GoodBoi { get; set; }
        public string FavoriteFood { get; set; }
        
        private string IsGood()
        {
            if (GoodBoi)
            {
                return "is a good boy";
            }
            else
            {
                return "is not a good boy";
            }
        }
        public override void PrintInfo()
        {
            
            base.PrintInfo();
            Console.WriteLine($"The dog {IsGood()} and it's favorite food is {FavoriteFood}.");

        }
    }
}
