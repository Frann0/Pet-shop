using System;
using System.Collections.Generic;
using Core.Models;

namespace Core.IServices
{
    public interface IPetTypeRepository
    {
        public List<PetType> ReadAllTypes();
    }
}