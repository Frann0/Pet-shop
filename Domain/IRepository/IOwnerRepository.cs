using System.Collections.Generic;
using Core.Models;

namespace Domain.IRepository
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