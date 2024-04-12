using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using WebApiDb.Models;
using WebApiDb.Models.DTOs;

namespace WebApiDb.AnimalsRepository;

public interface IAnimalsRepository
{
    public IEnumerable<Animal> GetAnimals();
    public void AddAnimal(AddAnimal addAnimal);

}