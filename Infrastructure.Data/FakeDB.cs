using System;
using System.Collections.Generic;
using Core.IServices;
using Core.Models;

namespace Infrastructure.Data
{
    public class FakeDB
    {
        private static int id;
        private static List<Pet> pets = new List<Pet>();
        private static List<Pet> petTypes = new List<Pet>();

        public FakeDB()
        {
            
        }

        public static void addPet(Pet pet)
        {
            pets.Add(pet);
        }
        public static List<Pet> GetPets()
        {
            return pets;
        }

        public static List<Pet> GetPetTypes()
        {
            return petTypes;
        }
    }
}