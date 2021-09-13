using System.Collections.Generic;
using HussmannDev.PetShopApp.Core.Models;

namespace HussmannDev.PetShopApp.Core.IServices
{
    public interface IOwnerService
    {
        Owner CreateOwner(Owner owner);

        Owner RemoveOwner(int id);

        Owner ReadOwnerById(int id);

        Owner UpdateOwner(Owner owner);

        List<Owner> ReadAllOwners();

    }
}