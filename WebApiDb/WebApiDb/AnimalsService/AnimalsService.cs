using WebApiDb.AnimalsRepository;
using WebApiDb.Models;
using WebApiDb.Models.DTOs;

namespace WebApiDb.AnimalsService;

public class AnimalsService : IAnimalsService
{
    private readonly IAnimalsRepository _animalsRepository;

    public AnimalsService(IAnimalsRepository animalsRepository)
    {
        _animalsRepository = animalsRepository;
    }


    public IEnumerable<Animal> GetAnimals(string orderBy)
    {
        return _animalsRepository.GetAnimals(orderBy);
    }
    

    public void AddAnimal(AddAnimal animal)
    {
        _animalsRepository.AddAnimal(animal);
    }
    

    public void UpdateAnimal(int id, AddAnimal animal)
    {
        _animalsRepository.UpdateAnimal(id, animal);
    }

    public void RemoveAnimal(int id)
    {
        _animalsRepository.RemoveAnimal(id);
    }
}