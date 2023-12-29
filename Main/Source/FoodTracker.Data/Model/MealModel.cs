namespace FoodTracker.Data.Model
{
    public class MealModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTimeOffset ConsumedAt { get; set; }

        public List<Guid>? Recipes { get; set; }

        public List<decimal>? Servings { get; set; }

        public decimal? Calories { get; set; }

        public MealModel(Guid id, string name, DateTimeOffset consumedAt, List<Guid> recipes, List<decimal> servings)
        {
            if (recipes.Count != servings.Count)
            {
                throw new ArgumentException("Count of recipes and servings must match.");
            }
            Id = id;
            Name = name;
            ConsumedAt = consumedAt;
            Recipes = recipes;
            Servings = servings;
        }

        public MealModel(Guid id, string name, DateTimeOffset consumedAt, decimal calories)
        {
            Id = id;
            Name = name;
            ConsumedAt = consumedAt;
            Calories = calories;
        }

        public MealModel(MealModel mealModel)
        {
            Id = mealModel.Id;
            Name = mealModel.Name;
            ConsumedAt = mealModel.ConsumedAt;
            Recipes = mealModel.Recipes;
            Servings = mealModel.Servings;
            Calories = mealModel.Calories;
        }
    }
}
