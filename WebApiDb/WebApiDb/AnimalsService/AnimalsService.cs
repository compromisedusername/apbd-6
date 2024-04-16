using WebApiDb.AnimalsRepository;
using WebApiDb.Models;
using WebApiDb.Models.DTOs;

namespace WebApiDb.AnimalsService;

public class AnimalsService(IAnimalsRepository animalsRepository) : IAnimalsService
{
    public IEnumerable<Animal> GetAnimals(string orderBy)
    {
        return animalsRepository.GetAnimals(orderBy);
    }
    
    

    public void AddAnimal(AddAnimal animal)
    {
        animalsRepository.AddAnimal(animal);
    }
    

    public void UpdateAnimal(int id, AddAnimal animal)
    {
        if (!animalsRepository.AnimalExists(id))
        {
            throw new BadHttpRequestException("No animal with id: " + id);
        }
        animalsRepository.UpdateAnimal(id, animal);
    }

    public void RemoveAnimal(int id)
    {
        if (!animalsRepository.AnimalExists(id))
        {
            throw new BadHttpRequestException("No animal with id: " + id);
        }
        animalsRepository.RemoveAnimal(id);
    }
}