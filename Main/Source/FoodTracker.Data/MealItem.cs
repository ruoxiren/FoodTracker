using FoodTracker.Data.DTO;
using static FoodTracker.Data.Constants.Constants;

namespace FoodTracker.Data
{
    public class MealItem
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ServingSizeOption ServingSize { get; set; }

        public decimal ServingAmount { get; set; }

        public decimal TotalCalories { get; set; }

        public string? Description { get; set; }

        public MealItem(Guid id, string name, ServingSizeOption servingSize, decimal servingAmount, decimal totalCalories, string? description = default)
        {
            Id = id;
            Name = name;
            ServingSize = servingSize;
            ServingAmount = servingAmount;
            TotalCalories = totalCalories;
            Description = description;
        }

        public override string ToString()
        {
            return $"Meal Item: Name: {Name}, Serving Size: {ServingSize}, Serving Amount: {ServingAmount}, Calories: {TotalCalories}";
        }
    }
}
