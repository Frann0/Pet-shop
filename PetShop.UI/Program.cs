using System;
using Core.IServices;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Pert_shop
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPetTypeRepository, PetTypeRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.AddScoped<IPetTypeService, PetTypeService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            
            IPetRepository petRepository = new PetRepository();
            IPetTypeRepository petTypeRepository = new PetTypeRepository();
            IPetService petService = new PetService(petRepository);
            Menu menu = new Menu(petService, petTypeRepository);
            menu.start();
        }
    }
    
}