using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.Entities
{
    public class Costumer
    {
        public List<Pet> BoughtPets { get; set; } = new List<Pet>();
        public string Name { get; set; }
        public int Money { get; set; }
    }
}
