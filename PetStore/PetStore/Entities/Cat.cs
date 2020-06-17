using PetStore.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.Entities
{
    public class Cat : Pet
    {
        public Cat()
        {
            Type = PetType.Cat;
        }
        public bool Lazy { get; set; }
        public int LivesLeft { get; set; }
        
        private string IsLazy()
        {
            if (Lazy)
            {
                return "is lazy";
            }
            else
            {
                return "is not lazy";
            }
        }
        public override void PrintInfo()
        {
            
            base.PrintInfo();
            Console.WriteLine($"The cat has {LivesLeft} lives left and {IsLazy()}.");
        }
    }
}
