using PetStore.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.Entities
{
    public class Fish : Pet
    {
        public Fish()
        {
            Type = PetType.Fish;
        }
        public string Color { get; set; }
        public FishSize Size { get; set; }
        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"The fish is {Color} and it is {Enum.GetName(typeof(FishSize),Size)} in size.");
        }
    }
}
