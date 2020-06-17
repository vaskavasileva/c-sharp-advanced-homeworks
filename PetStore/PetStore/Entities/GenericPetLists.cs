using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetStore.Entities
{
    public class GenericPetLists <T> where T : Pet
    {
        public List<T> PetList = new List<T>();
        public void PrintPets()
        {
            foreach (var item in PetList)
            {
                
                item.PrintInfo();
            }
            
        }
        

        public void BuyPet(string name)
        {
            var pet = PetList.SingleOrDefault(item => item.Name == name);
            if (pet == null)
            {
                Console.WriteLine("There is no such pet.");
                return;
            }
            PetList.Remove(pet);
            Console.WriteLine($"You succesfully bought {pet.Name}.");
        }

        public void AddPet(T pet)
        {
            PetList.Add(pet);
        }
    }
}
