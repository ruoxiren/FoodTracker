namespace FoodTracker.Data.DTO
{
    public class MealDto
    {
        public Guid Id { get; set; }

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

        public MealDto(Guid id, string mealName, DateTimeOffset consumedAt, List<MealItem> recipesAndServings)
        {
            if (recipesAndServings == null)
            {
                throw new ArgumentNullException(nameof(recipesAndServings));
            }
            Id = id;
            MealName = mealName;
            ConsumedAt = consumedAt;
            RecipesAndServings = recipesAndServings;
            TotalCalories = recipesAndServings.Sum(x => x.Calories);
        }

        public override string ToString()
        {
            return
                $"Meal Id: {Id}, Meal Name: {MealName}, Time: {ConsumedAt}, Total Calories: {TotalCalories}, RecipesAndServings: {(RecipesAndServings != null ? string.Join(", ", RecipesAndServings.Select(o => o.ToString())) : "null")}";
        }
    }
}