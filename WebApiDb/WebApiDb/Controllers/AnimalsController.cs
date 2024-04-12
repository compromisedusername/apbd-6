using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WebApiDb.AnimalsRepository;
using WebApiDb.Models;
using WebApiDb.Models.DTOs;

namespace WebApiDb.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class AnimalsController : ControllerBase
{
    private readonly IAnimalsRepository _animalsesRepository;
    
    public AnimalsController(IAnimalsRepository animalsesRepository)
    {
        _animalsesRepository = animalsesRepository;
    }
    
    [HttpGet]
    public IActionResult GetAnimals()
    {
        return Ok(_animalsesRepository.GetAnimals());
    }

    [HttpPost]
    public IActionResult AddAnimal(AddAnimal animal)
    {
       
        _animalsesRepository.AddAnimal(animal);
        
        // 201
        return Created("/api/animals", null);
    }
}