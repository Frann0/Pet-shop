using System;
using System.Collections.Generic;
using Core.Models;

namespace Core.IServices
{
    public interface IPetService
    {
        List<Pet> GetPets();
    }
}