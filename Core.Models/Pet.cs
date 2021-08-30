using System;

namespace Core.Models
{
    public class Pet
    {
        public int? Id { get; set; }
        public String Name { get; set; }
        public PetType Type { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime SoldTime { get; set; }
        public String Color { get; set; }
        public Double Price { get; set; }
    }
}