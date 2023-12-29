namespace FoodTracker.Data.DTO
{
    public class MealDto
    {
        public string MealName { get; set; }

        public DateTimeOffset ConsumedAt { get; set; }

        public List<MealItem>? RecipesAndServings { get; set; }

        public decimal TotalCalories { get; set; }

        public MealDto(string mealName, DateTimeOffset consumedAt, decimal totalCalories)
        {
            MealName = mealName;
            ConsumedAt = consumedAt;
            TotalCalories = totalCalories;
        }

        public MealDto(string mealName, DateTimeOffset consumedAt, List<MealItem> recipesAndServings)
        {
            if (recipesAndServings == null)
            {
                throw new ArgumentNullException(nameof(recipesAndServings));
            }
            MealName = mealName;
            ConsumedAt = consumedAt;
            RecipesAndServings = recipesAndServings;
            TotalCalories = recipesAndServings.Sum(x => x.Calories);
        }

        public override string ToString()
        {
            return
                $"Meal Name: {MealName}, Time: {ConsumedAt}, Total Calories: {TotalCalories}, RecipesAndServings: {(RecipesAndServings != null ? string.Join(", ", RecipesAndServings.Select(o => o.ToString())) : "null")}";
        }
    }
}