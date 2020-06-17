using PetStore.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.Entities
{
    public abstract class Pet
    {
        public string Name { get; set; }
        protected PetType Type { get; set; }
        public int Age { get; set; }
        public virtual void PrintInfo()
        {
            Console.WriteLine($"The name of the pet is {Name}, he is a {Enum.GetName(typeof(PetType), Type)} and he is {Age} years old."); 
        }
    }
}
