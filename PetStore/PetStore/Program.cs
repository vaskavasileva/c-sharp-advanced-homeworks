using PetStore.Entities;
using PetStore.Enums;
using System;

namespace PetStore
{
    class Program
    {
        public static GenericPetLists<Dog> Dogs = new GenericPetLists<Dog>();
        public static GenericPetLists<Cat> Cats = new GenericPetLists<Cat>();
        public static GenericPetLists<Fish> Fishes = new GenericPetLists<Fish>();

        static void Main(string[] args)
        {
            Dogs.AddPet(new Dog()
            {
                Name = "Max",
                Age = 6,
                GoodBoi = true,
                FavoriteFood = "Crackers" 
            });
            Dogs.AddPet(new Dog()
            {
                Name = "Ralph",
                Age = 2,
                GoodBoi = true,
                FavoriteFood = "Chicken meat"
            });
            Dogs.AddPet(new Dog()
            {
                Name = "Tara",
                Age = 4,
                GoodBoi = true,
                FavoriteFood = "Bread"
            });
            Cats.AddPet(new Cat()
            {
                Name = "Masha",
                Age = 8,
                Lazy = true,
                LivesLeft = 4
            });
            Cats.AddPet(new Cat()
            { Name = "Marko",
                Age = 9,
                Lazy = false,
                LivesLeft = 6 
            });
            Cats.AddPet(new Cat()
            {
                Name = "Sika",
                Age = 6,
                Lazy = true,
                LivesLeft = 2
            });
            Fishes.AddPet(new Fish()
            {
                Name = "Glog",
                Age = 1,
                Size = FishSize.Medium,
                Color = "Red"
            });
            Fishes.AddPet(new Fish()
            {
                Name = "Blab",
                Age = 3,
                Size = FishSize.Small,
                Color = "Yellow"
            });
            
            Dogs.BuyPet("Max");
            Cats.BuyPet("Sika");
            Dogs.PrintPets();
            Cats.PrintPets();
            Fishes.PrintPets();
        }
    }
}
