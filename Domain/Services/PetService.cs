using System;
using System.Collections.Generic;
using Core.IServices;
using Core.Models;

namespace Domain.Services
{
    public class PetService : IPetService
    {
        private PetRepository _petRepository;
        public PetService()
        {
            _petRepository = new PetRepository();
        }
        public List<Pet> GetPets()
        {
            return _petRepository.GetPets();
            throw new NotImplementedException();
        }
    }
}