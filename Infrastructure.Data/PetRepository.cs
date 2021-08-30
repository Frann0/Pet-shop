using System;
using System.Collections.Generic;
using Core.IServices;
using Core.Models;
using Infrastructure.Data;

public class PetRepository : IPetRepository
{

    public PetRepository()
    {
        FakeDB.addPet(new Pet
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
        return FakeDB.GetPets();
    }

    public List<Pet> GetPets()
    {
        return FakeDB.GetPets();
    }
}