using FoodTracker.Data.Enum;

namespace FoodTracker.Data.DTO
{
    public class RecipeDTO
    {
        public required string Name { get; set; }

        public required ServingSizeOption ServingSize { get; set; }

        public required decimal Calories { get; set; }

        public string? Description { get; set; }
    }
}
