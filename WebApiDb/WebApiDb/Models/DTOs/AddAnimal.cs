﻿using System.ComponentModel.DataAnnotations;

namespace WebApiDb.Models.DTOs;

public class AddAnimal
{
    
    [Required]
    [MinLength(5)]
    public string Name { get; set; }
    
    
    public string? Description { get; set; }
    
    [Required]
    [MinLength(5)]
    public string Category { get; set; }
    
    [Required]
    [MinLength(5)]
    public string Area { get; set; }
}