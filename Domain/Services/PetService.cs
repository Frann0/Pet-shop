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

        public Pet CreatePet(Pet pet)
        { 
           return _petRepository.CreatePet(pet);
        }

        public Pet UpdatePet(Pet pet)
        {
            return _petRepository.UpdatePet(pet);
        }

        public Pet DeletePet(int id)
        {
            return _petRepository.DeletePet(id);
        }
    }
}