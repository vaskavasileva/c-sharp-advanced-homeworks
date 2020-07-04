using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetStore.Entities
{
    public class GenericPetLists <T> where T : Pet
    {
        public List<T> PetList { get; set; } = new List<T>();
        public void PrintPets()
        {
            foreach (var item in PetList)
            {
                
                item.PrintInfo();
            }
            
        }
        

        public void BuyPet(string name, Costumer costumer)
        {
            var pet = PetList.SingleOrDefault(item => item.Name == name);
            if (pet == null)
            {
                Console.WriteLine("There is no such pet.");
                throw new Exception("No pet found.");
            }
            PetList.Remove(pet);
            costumer.BoughtPets.Add(pet);
            Console.WriteLine($"You succesfully bought {pet.Name}.");
        }

        public void AddPet(T pet)
        {
            PetList.Add(pet);
        }
    }
}
