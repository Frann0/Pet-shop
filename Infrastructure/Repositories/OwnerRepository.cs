using System.Collections.Generic;
using System.Linq;
using Core.Models;
using Domain.IRepository;
using Infrastructure.Converters;
using Infrastructure.Entities;

namespace Infrastructure.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private static List<OwnerEntity> _ownersTable = new List<OwnerEntity>();
        private static int _id = 1;
        private readonly OwnerConverter _ownerConverter;

        public OwnerRepository()
        {
            _ownerConverter = new OwnerConverter();

            CreateOwner(new Owner()
            {
                Name = "Ole",
                Age = 21
            });
            CreateOwner(new Owner()
            {
                Name = "Mike",
                Age = 21
            });
        }
        public Owner CreateOwner(Owner owner)
        {
            var ownerEntity = _ownerConverter.Convert(owner);
            ownerEntity.Id = _id++;
            _ownersTable.Add(ownerEntity);
            return _ownerConverter.Convert(ownerEntity);
        }

        public Owner ReadOwnerById(int id)
        {
            foreach (var ownerEntity in _ownersTable)
            {
                if (ownerEntity.Id == id)
                {
                    return _ownerConverter.Convert(ownerEntity);
                }
            }

            return null;
        }

        public Owner UpdateOwner(Owner owner)
        {
            var ownerOld = _ownersTable.FirstOrDefault(o => o.Id == owner.Id);
            if (ownerOld != null)
            {
                ownerOld.Name = owner.Name;
                ownerOld.Age = owner.Age;
            }

            return null;
        }

        public Owner RemoveOwner(int id)
        {
            var owner = ReadOwnerById(id);
            _ownersTable.Remove(_ownersTable.FirstOrDefault(p => p.Id == id));
            return owner;
        }

        public List<Owner> ReadAllOwners()
        {
            var listOfOwners = new List<Owner>();
            foreach (var owner in _ownersTable)
            {
                listOfOwners.Add(_ownerConverter.Convert(owner));
            }

            return listOfOwners;
        }
    }
}