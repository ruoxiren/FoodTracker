using FoodTracker.Data.DTO;
using FoodTracker.Data.Model;
using FoodTracker.Data.Repository.Extensions;
using FoodTracker.Data.Repository.Interfaces;

namespace FoodTracker.Services
{
    public class MealService
    {
        private readonly IMealRepository _mealRepository;
        private readonly IMealItemRepository _mealItemRepository;

        public MealService(IMealRepository mealRepository, IMealItemRepository mealItemRepository)
        {
            _mealRepository = mealRepository;
            _mealItemRepository = mealItemRepository;
        }

        public void AddMeal(MealDto meal)
        {
            _mealItemRepository.AddMealItems(meal.MealItems.Select(
                mealItem =>
                    new MealItemModel(mealItem.Id, mealItem.Name, mealItem.ServingSize.ToString(), mealItem.ServingAmount, mealItem.TotalCalories, mealItem.Description)
                ).ToList());
            _mealRepository.AddMeal(meal.ToModel());
        }

        public void UpdateMeal(Guid mealId, MealDto meal)
        {
            var existingMeal = _mealRepository.GetMealById(mealId);
            if (existingMeal == null)
            {
                throw new ArgumentNullException($"Can not find meal of id {mealId}");
            }

            // Delete meal item if no longer exists
            var mealItemIds = meal.MealItems.Select(m => m.Id).ToList();
            var mealItemIdToBeDeleted = existingMeal.MealItems.Where(id => !mealItemIds.Contains(id)).ToList();
            mealItemIdToBeDeleted.ForEach(m => _mealItemRepository.DeleteMealItemById(m));

            // Update meal
            _mealRepository.UpsertMeal(mealId, new MealModel(meal.Id, meal.Name, meal.ConsumedAt, mealItemIds, meal.Description));
            
            // Update meal item
            meal.MealItems.ForEach(m => _mealItemRepository.UpsertMealItem(m.Id, m.ToModel()));
        }

        public List<MealDto> GetMeals(DateTimeOffset start, DateTimeOffset end)
        {
            var meals = new List<MealDto>();
            var result = _mealRepository.GetMeals().Where(x => x.ConsumedAt > start && x.ConsumedAt < end).ToList();
            foreach (var meal in result)
            {
                meals.Add(meal.ToDto(_mealItemRepository));
            }
            return meals;
        }

        public void DeleteMeal(Guid mealId)
        {
            // Delete meal item if no longer exists
            var existingMeal = _mealRepository.GetMealById(mealId);
            if (existingMeal == null)
            {
                throw new ArgumentNullException($"Can not find meal of id {mealId}");
            }

            // Delete meal item
            existingMeal.MealItems.ForEach(_mealItemRepository.DeleteMealItemById);

            // Delete meal
            _mealRepository.DeleteMealById(mealId);
        }
    }
}
