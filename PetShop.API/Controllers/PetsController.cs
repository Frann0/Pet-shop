using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.IServices;
using Core.Models;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PetShop.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpPost]
        public Pet Create(Pet pet)
        {
            return _petService.CreatePet(pet);
        }

        [HttpGet]
        public List<Pet> GetAll()
        {
            return _petService.ReadPets();
        }

        [HttpPut("{id}")]
        public Pet Edit(Pet pet)
        {
            return _petService.UpdatePet(pet);
        }

        [HttpDelete("{id}")]
        public Pet Delete(int id)
        {
            return _petService.DeletePet(id);
        }
    }
}