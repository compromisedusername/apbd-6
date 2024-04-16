using WebApiDb.AnimalsRepository;
using WebApiDb.Models;
using WebApiDb.Models.DTOs;

namespace WebApiDb.AnimalsService;

public interface IAnimalsService
{
    public IEnumerable<Animal> GetAnimals(string orderBy);
    public void AddAnimal(AddAnimal animal);
    public void UpdateAnimal(int id, AddAnimal animal);
    public void RemoveAnimal(int id);


}