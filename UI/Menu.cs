using System;
using System.Collections.Generic;
using Core.Models;
using Domain.Services;

internal class Menu
    {
        private readonly PetService _PetService;

        public Menu()
        {
            _PetService = new PetService();
        }

        public void start()
        {
            //Print(StringConstants.WelcomeGreeting);
            //StartLoop();

            Print(_PetService.GetPets().Count.ToString());
            foreach (var pet in _PetService.GetPets())
            {
                Print(pet.Id + " - " + pet.Name + " - " + pet.Type.Name + " - " + pet.Birthdate + " - " + pet.SoldTime + " - " + pet.Color + " - " + pet.Price);
            } 
            
        }

       
        
        private void Print(string value)
        {
            Console.WriteLine(value);
        }
    }