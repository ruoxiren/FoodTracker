using FoodTracker.Data.Model;
using FoodTracker.Data.Repository.Interfaces;

namespace FoodTracker.Data.Repository.InMemory
{
    public class InMemoryMealRepository : IMealRepository
    {
        private static readonly List<MealModel> meals = new List<MealModel>()
        {
            new MealModel(Guid.NewGuid(), "Weekend Meal", DateTimeOffset.UtcNow, 1000),
            new MealModel(Guid.NewGuid(), "Weekday Meal", DateTimeOffset.UtcNow, 800),
        };

        public void AddMeal(MealModel meal)
        {
            if (meal == null)
            {
                throw new ArgumentNullException(nameof(meal));
            }

            if (meal.Id == Guid.Empty)
            {
                meal.Id = Guid.NewGuid();
            }
            meals.Add(meal);
        }

        public MealModel? GetMealById(Guid id)
        {
            var result = meals.FirstOrDefault(m => m.Id == id);
            return result;
        }

        public MealModel? GetMealByName(string name)
        {
            var result = meals.FirstOrDefault(x => x.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
            return result;
        }

        public void DeleteMealById(Guid id)
        {
            meals.RemoveAll(m => m.Id == id);
        }

        public List<MealModel> GetMeal()
        {
            var list = new List<MealModel>();
            meals.ForEach(m => list.Add(new(m)));
            return list;
        }

        public void UpdateMeal(Guid mealId, MealModel meal)
        {
            var result = meals.FirstOrDefault(x => x.Id == mealId);

            if (result != null)
            {
                result.Name = meal.Name;
                result.ConsumedAt = meal.ConsumedAt;
                result.Recipes = meal.Recipes;
                result.Servings = meal.Servings;
                result.Calories = meal.Calories;
            }
            else
            {
                throw new ArgumentNullException(nameof(meal));
            }
        }
    }
}
