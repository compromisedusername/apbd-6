using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using WebApiDb.Models;
using WebApiDb.Models.DTOs;

namespace WebApiDb.AnimalsRepository;

public interface IAnimalsRepository
{
    public IEnumerable<Animal> GetAnimals(string query);
    public void AddAnimal(AddAnimal addAnimal);
    public void UpdateAnimal(int id, AddAnimal animal);
    public void RemoveAnimal(int id);
    public bool AnimalExists(int id);

}