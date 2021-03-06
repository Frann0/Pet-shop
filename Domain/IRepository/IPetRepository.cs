using System;
using System.Collections.Generic;
using Core.Models;

namespace Core.IServices
{
    public interface IPetRepository
    {
        List<Pet> ReadPets();

        Pet CreatePet(Pet pet);

        Pet UpdatePet(Pet pet);

        Pet DeletePet(int id);
    }
}