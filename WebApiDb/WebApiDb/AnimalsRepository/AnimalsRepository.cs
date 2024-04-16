using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.OpenApi.Extensions;
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

    public IEnumerable<Animal> GetAnimals(string orderBy)
    {
        using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        connection.Open();

        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        
        command.CommandText = "SELECT IdAnimal, Name, Description, Category, Area FROM Animal ORDER BY CASE WHEN @orderBy = 'name' THEN Name WHEN @orderBy = 'description' THEN Description WHEN @orderBy = 'area' THEN Area WHEN @orderBy = 'category' THEN Category ELSE Name END";
        command.Parameters.AddWithValue("orderBy", orderBy);

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
                IdAnimal = reader.GetInt32(idAnimalOrdinal),
                Name = reader.GetString(nameOrdinal),
                Category = reader.GetString(CategoryOrdinal),
                Description = reader.GetString(DescriptionOrdinal),
                Area = reader.GetString(AreaOrdinal)
            });
            
        }

        return animals;
    }

    public bool AnimalExists(int id)
    {
        using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        connection.Open();

        SqlCommand command = new SqlCommand();
        command.Connection = connection;

        command.CommandText = "SELECT 1 FROM Animal WHERE IdAnimal = @animalId";
        command.Parameters.AddWithValue("animalId", id);

        var reader = command.ExecuteReader();

        return reader.HasRows;
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

    public void UpdateAnimal(int id, AddAnimal animal)
    {
        using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        connection.Open();

        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        
        command.CommandText = "UPDATE Animal SET Name = @animalName, Description = @animalDescription, Category = @animalCategory, Area = @animalArea WHERE IdAnimal = @animalId;";
        command.Parameters.AddWithValue("animalId", id);
        
        command.Parameters.AddWithValue("animalName", animal.Name);
        command.Parameters.AddWithValue("animalDescription", animal.Description);
        command.Parameters.AddWithValue("animalCategory", animal.Category);
        command.Parameters.AddWithValue("animalArea", animal.Area);

        command.ExecuteNonQuery();
    }

    public void RemoveAnimal(int id)
    {
        using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        connection.Open();

        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        
        command.CommandText = "DELETE FROM Animal WHERE IdAnimal = @id;";
        command.Parameters.AddWithValue("id", id);

        command.ExecuteNonQuery();

    }
}