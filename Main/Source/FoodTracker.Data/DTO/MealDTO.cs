namespace FoodTracker.Data.DTO
{
    public class MealDto
    {
        public required string MealName { get; set; }

        public required DateTimeOffset ConsumedAt { get; set; }

        public required List<MealItem> RecipesAndServings { get; set; }

        public required decimal TotalCalories { get; set; }

        public override string ToString()
        {
            return
                $"Meal Name: {MealName}, Time: {ConsumedAt}, Total Calories: {TotalCalories}, RecipesAndServings: {string.Join(", ", RecipesAndServings.Select(o => o.ToString()))}";
        }
    }
}
