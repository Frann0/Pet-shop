using System;
using System.Collections.Generic;
using Core.IServices;
using Core.Models;


public class PetRepository : IPetRepository
{

    private static int id;
    private static List<Pet> pets = new List<Pet>();
    private static List<Pet> petTypes = new List<Pet>();
    public PetRepository()
    {
    
        pets.Add(new Pet
        {
            Id = 1,
            Name = "Oskar",
            Type = new PetType
            {
                Id = 1,
                Name = "Hund"
            },
            Birthdate = DateTime.Now,
            SoldTime = DateTime.Now,
            Color = "Brun",
            Price = 1000.00
        });
}
    

    public List<Pet> ReadPets()
    {
        return pets;
    }
}