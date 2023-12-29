using FoodTracker.Data.Model;
using FoodTracker.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void DeleteMealById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<MealModel> GetMeal()
        {
            throw new NotImplementedException();
        }

        public MealModel? GetMealById(Guid id)
        {
            throw new NotImplementedException();
        }

        public MealModel? GetMealByName(string name)
        {
            throw new NotImplementedException();
        }

        public void UpdateMeal(Guid mealId, MealModel meal)
        {
            throw new NotImplementedException();
        }
    }
}
