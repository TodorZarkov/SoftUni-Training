﻿
namespace WildFarm.Factories.Interfaces
{
    
    using WildFarm.Models.Interfaces;

    public interface IAnimalFactory
    {
        IAnimal CreateAnimal(params string[] animalData);
    }
}
