using System;
using System.Collections.Generic;
using Core.Models;

namespace Core.IServices
{
    public interface IPetService
    {
        List<Pet> ReadPets();

        void CreatePet(Pet pet);

        void UpdatePet(Pet pet);

        void DeletePet(int id);
    }
}