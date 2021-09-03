using System;
using System.Collections.Generic;
using System.Linq;
using Core.IServices;
using Core.Models;
using Domain.Services;
using UI;

internal class Menu
    {
        private  IPetService _PetService;
        private  IPetTypeRepository _PetTypeRepository;
        

        public Menu(IPetService service, IPetTypeRepository petTypeRepository)
        {
            _PetService = service;
            _PetTypeRepository = petTypeRepository;
        }

        public void start()
        {
            Print(StringConstants.WelcomeGreeting);
            ShowMainMenu();
            StartLoop();
        }

        private void StartLoop()
        {
            int choice;
            while ((choice = GetMainMenuSelection()) != 0)
            {
                switch (choice)
                {
                    //Show pets
                    case 1:
                        ReadAllPets();
                        ShowMainMenu();
                        break;
                    //Search pets
                    case 2:
                        SearchByType();
                        ShowMainMenu();
                        break;
                    //Create pets
                    case 3:
                        CreatePet();
                        ShowMainMenu();
                        break;
                    //Delete pets
                    case 4:
                        DeletePet();
                        ShowMainMenu();
                        break;
                    //Update pets
                    case 5:
                        UpdatePet();
                        ShowMainMenu();
                        break;
                    //ShowByPrice pets
                    case 6:
                        SortByPrice();
                        ShowMainMenu();
                        break;
                    //ShowCheapest pet
                    case 7:
                        ShowCheapestPet();
                        ShowMainMenu();
                        break;
                    //Exit petshop
                    case 0:
                        break;
                    //Error message
                    case -1:
                        Print(StringConstants.ErrorMessage);
                        break;
                }
            }
        }

        
        private int GetMainMenuSelection()
        {
            var selectionString = Console.ReadLine();
            int selection;
            if (int.TryParse(selectionString, out selection))
            {
                return selection;
            }
            return -1;
        }

        private void ShowMainMenu()
        {
            Print("");
            Print(StringConstants.Lines);
            Print(StringConstants.ShowPetsMenuMessage);
            Print(StringConstants.SearchPetsByTypeMenuMessage);
            Print(StringConstants.CreatePetMenuMessage);
            Print(StringConstants.DeletePetMenuMessage);
            Print(StringConstants.UpdatePetMenuMessage);
            Print(StringConstants.SortPetsByPriceMessage);
            Print(StringConstants.ShowCheapestPetsMenuMessage);
        }

        private void ShowCheapestPet()
        {
            List<Pet> orderedPets = _PetService.ReadPets().OrderBy(p => p.Price).ToList();
            for (int i = 0; i < 5; i++)
            {
                Print(orderedPets[i].Id + " - " + orderedPets[i].Name + " - " + orderedPets[i].Type.Name + " - " 
                      + orderedPets[i].Birthdate + " - " + orderedPets[i].SoldTime + " - " + orderedPets[i].Color 
                      + " - " + orderedPets[i].Price);
            }
        }

        private void SortByPrice()
        {
            foreach (var p in _PetService.ReadPets().OrderBy(p => p.Price).ToList())
            {
                Print(p.Id + " - " + p.Name + " - " + p.Type.Name + " - " + p.Birthdate + " - " + p.SoldTime + " - " + p.Color + " - " + p.Price);
            }
        }

        private void UpdatePet()
        {
            ReadAllPets();
            Print(StringConstants.SelectPetToUpate);
            var petToUpdate = _PetService.ReadPets().Find(p => p.Id == GetMainMenuSelection());
            Print($"Please enter a new name for {petToUpdate.Name}: ");
            var name = Console.ReadLine();
            Print($" Old color was {petToUpdate.Color}. Please enter a new color: ");
            var color = Console.ReadLine();
            Print($"Old Birthday was {petToUpdate.Birthdate.Date}. Please enter a new Birthday (dd-MM-yyyy): ");
            var birthDay = DateTime.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            var soldDate = DateTime.Now;
            double x;
            Print($"Old price was {petToUpdate.Price}, please enter a new price: ");
            double price = double.TryParse(Console.ReadLine(), out x) ? x : 0;
            PrintPetTypes();
            Print(StringConstants.CreatePetType);
            int typeID = GetMainMenuSelection();
            
            _PetService.UpdatePet(new Pet()
            {
                Birthdate = birthDay,
                Color = color,
                Id = petToUpdate.Id,
                Name = name,
                Price = price,
                SoldTime = soldDate,
                Type = _PetTypeRepository.ReadAllTypes().Find(i => i.Id == typeID)
            });
        }

        private void DeletePet()
        {
            ReadAllPets();
            Print(StringConstants.DeletePetText);
            _PetService.DeletePet(GetMainMenuSelection());
        }

        private void CreatePet()
        {
            Print(StringConstants.CreatePetText);
            Print(StringConstants.Lines);
            Print(StringConstants.CreatePetName);
            var name = Console.ReadLine();
            Print(StringConstants.CreatePetColor);
            var color = Console.ReadLine();
            Print(StringConstants.CreatePetBirthday);
            var birthday = DateTime.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            var soldDate = DateTime.Now;
            double x;
            Print(StringConstants.CreatePetPrice);
            double price = double.TryParse(Console.ReadLine(), out x) ? x : 0;
            PrintPetTypes();
            Print(StringConstants.CreatePetType);
            int typeID = GetMainMenuSelection();

            _PetService.CreatePet(new Pet()
            {
                Birthdate = birthday,
                Color = color,
                Id = null,
                Name = name,
                Price = price,
                SoldTime = soldDate,
                Type = _PetTypeRepository.ReadAllTypes().Find(i => i.Id == typeID)
            });
        }

        private void SearchByType()
        {
            Print(StringConstants.SearchPetsByTypeMenuMessage);
            PrintPetTypes();

            int selectedId = GetMainMenuSelection();
            Print(StringConstants.Lines);
            Print($"All pets of type {_PetTypeRepository.ReadAllTypes().Find(name => name.Id == selectedId)?.Name}");
            foreach (var pet in _PetService.ReadPets().FindAll(pet => pet.Type.Id == selectedId))
            {
                Print($"Id: {pet.Id} - Name: {pet.Name} - Color: {pet.Color} - Price: {pet.Price}");
            }
            
        }

        private void PrintPetTypes()
        {
            foreach (var types in _PetTypeRepository.ReadAllTypes())
            {
                Print($"Id - {types.Id} - {types.Name}");
            }
        }

        private void ReadAllPets()
        
        {
            foreach (var pet in _PetService.ReadPets())
            {
                Print(pet.Id + " - " + pet.Name + " - " + pet.Type.Name + " - " + pet.Birthdate + " - " + pet.SoldTime + " - " + pet.Color + " - " + pet.Price);
            } 
        }


        private void Print(string value)
        {
            Console.WriteLine(value);
        }
    }