using System;
using System.Collections.Generic;
using Core.IServices;
using Core.Models;

namespace Domain.Services
{
    public class PetService : IPetService
    {
        private IPetRepository _petRepository;
        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }
        public List<Pet> ReadPets()
        {
            return _petRepository.ReadPets();
        }

        public void CreatePet(Pet pet)
        { 
            _petRepository.CreatePet(pet);
        }

        public void UpdatePet(Pet pet)
        {
            _petRepository.UpdatePet(pet);
        }

        public void DeletePet(int id)
        {
            _petRepository.DeletePet(id);
        }
    }
}