using Core.IServices;
using Core.Models;
using Infrastructure.Entities;

namespace Infrastructure.Converters
{
    public class PetConverter
    {
        private IPetTypeRepository _petTypeRepo = new PetTypeRepository();
        public PetEntity Convert(Pet pet)
        {
            return new PetEntity()
            {
                Id = pet.Id,
                Name = pet.Name,
                TypeId = pet.Type.Id,
                Color = pet.Color,
                Price = pet.Price,
                BirthDate = pet.Birthdate,
                SoldDate = pet.SoldTime
            };
        }

        public Pet Convert(PetEntity petEntity)
        {
            return new Pet()
            {
                Id = petEntity.Id,
                Birthdate = petEntity.BirthDate,
                Color = petEntity.Color,
                Name = petEntity.Name,
                Price = petEntity.Price,
                SoldTime = petEntity.SoldDate,
                Type = _petTypeRepo.ReadAllTypes().Find(i => i.Id == petEntity.TypeId)
            };
        }
    }
}