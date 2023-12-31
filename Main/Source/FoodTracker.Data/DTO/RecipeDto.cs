﻿using FoodTracker.Data.Constants;
using System.Text.Json.Serialization;

namespace FoodTracker.Data.DTO
{
    public class RecipeDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ServingSizeOption ServingSize { get; set; }

        public decimal Calories { get; set; }

        public string? Description { get; set; }

        [JsonConstructor]
        public RecipeDto(Guid id, string name, string servingSize, decimal calories, string? description = default)
        {
            Id = id;
            Name = name;
            ServingSize = (ServingSizeOption)Enum.Parse(typeof(ServingSizeOption), servingSize);
            Calories = calories;
            Description = description;
        }
    }
}
