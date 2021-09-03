using System;
using System.Collections.Generic;
using Core.IServices;
using Core.Models;


public class PetTypeRepository : IPetTypeRepository
{

    private static int id;
    private static List<PetType> petTypes;
    public PetTypeRepository()
    {
        petTypes = new List<PetType>();
        
        petTypes.Add(new PetType()
        {
            Id = 1,
            Name = "Dog"
        });
        petTypes.Add(new PetType()
        {
            Id = 2,
            Name = "Cat"
        });
        petTypes.Add(new PetType()
        {
            Id = 3,
            Name = "Goat"
        });
        petTypes.Add(new PetType()
        {
            Id = 4,
            Name = "Rat"
        });
        petTypes.Add(new PetType()
        {
            Id = 5,
            Name = "Snake"
        });
        petTypes.Add(new PetType()
        {
            Id = 6,
            Name = "Fish"
        });
}
    

    public List<PetType> ReadAllTypes()
    {
        return petTypes;
    }
}