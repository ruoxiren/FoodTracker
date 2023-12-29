using FoodTracker.Data.Constants;
using System;
using static FoodTracker.Data.Constants.Constants;

namespace FoodTracker.Data.DTO
{
    public class RecipeDto
    {
        public string Name { get; set; }

        public ServingSizeOption ServingSize { get; set; }

        public decimal Calories { get; set; }

        public string? Description { get; set; }

        public RecipeDto(string name, string servingSize, decimal calories, string? description = default)
        {
            Name = name;
            ServingSize = (ServingSizeOption)Enum.Parse(typeof(ServingSizeOption), servingSize);
            Calories = calories;
            Description = description;
        }
    }
}
