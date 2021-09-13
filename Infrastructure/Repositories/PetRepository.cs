using System;
using System.Collections.Generic;
using System.Linq;
using Core.IServices;
using Core.Models;
using Infrastructure.Converters;
using Infrastructure.Entities;


public class PetRepository : IPetRepository
{

    private static int id = 1;
    private static List<PetEntity> pets = new List<PetEntity>();
    private List<PetType> types = new PetTypeRepository().ReadAllTypes();
    private readonly PetConverter _petConverter;
    
    public PetRepository()
    {
        _petConverter = new PetConverter();
        
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
        List<Pet> allPets = new List<Pet>();
        foreach (var pet in pets)
        {
            allPets.Add(_petConverter.Convert(pet));
        }

        return allPets;
    }

    public Pet CreatePet(Pet pet)
    {
        var petEntity = _petConverter.Convert(pet);
        petEntity.Id = id++;
        pets.Add(petEntity);
        return _petConverter.Convert(petEntity);
    }

    public Pet UpdatePet(Pet pet)
    {
        var old = pets.FirstOrDefault(p => p.Id == pet.Id);
        
        if (old != null)
        {
            old.Name = pet.Name;
            old.Color = pet.Color;
            old.Price = pet.Price;
            old.BirthDate = pet.Birthdate;
            old.SoldDate = pet.SoldTime;
            old.TypeId = pet.Type.Id;
        }

        return null;
    }

    public Pet DeletePet(int id)
    {
        var pet = pets.Find(p => p.Id == id);
        pets.Remove(pet);
        return _petConverter.Convert(pet);
    }
}