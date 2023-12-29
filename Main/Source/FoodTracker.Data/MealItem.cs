using FoodTracker.Data.DTO;

namespace FoodTracker.Data
{
    public class MealItem
    {
        public required RecipeDto Recipe { get; set; }

        public required decimal ServingSize { get; set; }

        public decimal Calories { get { return Recipe.Calories * ServingSize; } }

        public MealItem(RecipeDto recipe, decimal servingSize)
        {
            Recipe = recipe;
            ServingSize = servingSize;
        }

        public override string ToString()
        {
            return $"Recipe: {Recipe.Name}, Serving Size: {ServingSize}, Calories: {Calories}";
        }
    }
}
