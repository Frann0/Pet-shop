using System;
using System.Collections.Generic;
using System.Linq;
using Core.IServices;
using Core.Models;


public class PetRepository : IPetRepository
{

    private static int id = 1;
    private static List<Pet> pets = new List<Pet>();
    private List<PetType> types = new PetTypeRepository().ReadAllTypes();

    public PetRepository()
    {
    
        CreatePet(new Pet
        {
            Name = "Oskar",
            Type = types[0],
            Birthdate = DateTime.Now,
            SoldTime = DateTime.Now,
            Color = "Brun",
            Price = 1000
        });
        CreatePet(new Pet
        {
            Name = "Ole",
            Type = types[2],
            Birthdate = DateTime.Now,
            SoldTime = DateTime.Now,
            Color = "Gul",
            Price = 2000
        });
        CreatePet(new Pet
        {
            Name = "Jens",
            Type = types[4],
            Birthdate = DateTime.Now,
            SoldTime = DateTime.Now,
            Color = "Gul",
            Price = 200
        });
        CreatePet(new Pet
        {
            Name = "Henrik",
            Type = types[0],
            Birthdate = DateTime.Now,
            SoldTime = DateTime.Now,
            Color = "Blå",
            Price = 6000
        });
        CreatePet(new Pet
        {
            Name = "Ulla",
            Type = types[3],
            Birthdate = DateTime.Now,
            SoldTime = DateTime.Now,
            Color = "Brun",
            Price = 100
        });
        CreatePet(new Pet
        {
            Name = "Ejnar",
            Type = types[0],
            Birthdate = DateTime.Now,
            SoldTime = DateTime.Now,
            Color = "Brun",
            Price = 20
        });
}
    

    public List<Pet> ReadPets()
    {
        return pets;
    }

    public Pet CreatePet(Pet pet)
    {
        pet.Id = id++;
        pets.Add(pet);
        return pet;
    }

    public Pet UpdatePet(Pet pet)
    {
        var old = pets.FirstOrDefault(p => p.Id == pet.Id);
        
        if (old != null)
        {
            old.Name = pet.Name;
            old.Color = pet.Color;
            old.Price = pet.Price;
            old.Birthdate = pet.Birthdate;
            old.SoldTime = pet.SoldTime;
            old.Type.Id = pet.Type.Id;
        }

        return null;
    }

    public void DeletePet(int id)
    {
        pets.Remove(pets.Find(p => p.Id == id));
    }
}