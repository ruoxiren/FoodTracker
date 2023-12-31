using FoodTracker.Data.Model;
using FoodTracker.Data.Repository.Interfaces;

namespace FoodTracker.Data.Repository.InMemory
{
    public class InMemoryMealRepository : IMealRepository
    {
        private static readonly List<MealModel> meals = new List<MealModel>()
        {
            new MealModel(Guid.NewGuid(), "Weekend Meal", DateTimeOffset.Parse("2023-12-30T00:00:00Z"), new List<Guid>(){ InMemoryMealItemRepository.InMemoryMealItems[3].Id }),
            new MealModel(Guid.NewGuid(), "Weekday Meal", DateTimeOffset.Parse("2023-12-29T00:00:00Z"), new List<Guid>(){ InMemoryMealItemRepository.InMemoryMealItems[0].Id, InMemoryMealItemRepository.InMemoryMealItems[1].Id, InMemoryMealItemRepository.InMemoryMealItems[2].Id }),
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

        public List<MealModel> GetAllMeal()
        {
            var list = new List<MealModel>();
            meals.ForEach(m => list.Add(new(m)));
            return list;
        }

        // Update or add
        public void UpsertMeal(Guid id, MealModel meal)
        {
            var result = meals.FirstOrDefault(x => x.Id == id);

            if (result != null)
            {
                result.Name = meal.Name;
                result.ConsumedAt = meal.ConsumedAt;
                result.MealItems = meal.MealItems;
                result.Description = meal.Description;
            }
            else
            {
                AddMeal(meal);
            }
        }

        public List<MealModel> GetMeals()
        {
            var list = new List<MealModel>();
            meals.ForEach(x => list.Add(new(x)));
            return list;
        }
    }
}
