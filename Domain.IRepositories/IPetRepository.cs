using System;
using System.Collections.Generic;
using Core.Models;

namespace Core.IServices
{
    public interface IPetRepository
    {
        List<Pet> ReadPets();
    }
}