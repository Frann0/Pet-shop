using System.Collections.Generic;
using HussmannDev.PetShopApp.Core.Models;

namespace HussmannDev.PetShopApp.Domain.IRepositories
{
    public interface IOwnerRepository
    {
        Owner CreateOwner(Owner owner);

        Owner ReadOwnerById(int id);

        Owner UpdateOwner(Owner owner);

        Owner RemoveOwner(int id);

        List<Owner> ReadAllOwners();
    }
}