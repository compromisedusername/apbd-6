using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WebApiDb.Controllers;
using WebApiDb.Models;
using WebApiDb.Models.DTOs;

namespace WebApiDb.AnimalsRepository;

public class AnimalsRepository : IAnimalsRepository


{

    private readonly IConfiguration _configuration;

    public AnimalsRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IEnumerable<Animal> GetAnimals()
    {
        using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        connection.Open();

        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        
        // command.CommandText = "INSERT INTO Animal VALUES ('Animal1','Desc1','Cat1','Area1');";
        command.CommandText = "SELECT * FROM Animal;";

        var animals = new List<Animal>();
        var reader = command.ExecuteReader();


        int idAnimalOrdinal = reader.GetOrdinal("IdAnimal");
        int nameOrdinal = reader.GetOrdinal("Name");
        int DescriptionOrdinal = reader.GetOrdinal("Description");
        int CategoryOrdinal = reader.GetOrdinal("Category");
        int AreaOrdinal = reader.GetOrdinal("Area");
        
        while (reader.Read())
        {
            animals.Add(new Animal()
            {
                IdAnimal = reader.GetInt32(0),
                Name = reader.GetString(nameOrdinal),
                Category = reader.GetString(CategoryOrdinal),
                Description = reader.GetString(DescriptionOrdinal),
                Area = reader.GetString(AreaOrdinal)
            });
            
        }

        return animals;
    }

    public void AddAnimal(AddAnimal addAnimal)
    {
        using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        connection.Open();

        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        
        command.CommandText = "INSERT INTO Animal VALUES (@animalName,@animalDescription,@animalCategory,@animalArea);";
       
        command.Parameters.AddWithValue("animalName", addAnimal.Name);
        command.Parameters.AddWithValue("animalDescription", addAnimal.Category);
        command.Parameters.AddWithValue("animalCategory", addAnimal.Description);
        command.Parameters.AddWithValue("animalArea", addAnimal.Area);

        command.ExecuteNonQuery();
    }
}