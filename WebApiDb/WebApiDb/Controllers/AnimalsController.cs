using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WebApiDb.AnimalsRepository;
using WebApiDb.AnimalsService;
using WebApiDb.Models;
using WebApiDb.Models.DTOs;

namespace WebApiDb.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class AnimalsController : ControllerBase
{
    private readonly IAnimalsService _animalsService;
    
    public AnimalsController(IAnimalsService animalsService)
    {
        _animalsService = animalsService;
    }
    
    [HttpGet]
    public IActionResult GetAnimals([RegularExpression(@"name|description|area|category|()")]string orderBy = "")
    {
        return Ok(_animalsService.GetAnimals(orderBy));
    }

    [HttpPost]
    public IActionResult AddAnimal(AddAnimal animal)
    {
       
        _animalsService.AddAnimal(animal);
        
        // 201
        return Created("/api/animals", null);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        _animalsService.RemoveAnimal(id);
        return Ok();
    }
    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(int id, AddAnimal animal)
    {
        _animalsService.UpdateAnimal(id,animal);
        return Ok();
    }
}