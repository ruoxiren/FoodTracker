using FoodTracker.Data;
using FoodTracker.Data.Constants;
using FoodTracker.Data.DTO;
using FoodTracker.Data.Model;
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
            _mealRepository.AddMeal(MealDtoToModel(meal));
        }

        public void UpdateMeal(Guid mealId, MealDto meal)
        {
            // Delete meal item if no longer exists
            var existingMeal = _mealRepository.GetMealById(mealId);
            if (existingMeal == null)
            {
                throw new ArgumentNullException($"Can not find meal of id {mealId}");
            }

            var mealItemIds = meal.MealItems.Select(m => m.Id).ToList();
            var mealItemIdToBeDeleted = existingMeal.MealItems.Where(id => !mealItemIds.Contains(id)).ToList();
            mealItemIdToBeDeleted.ForEach(m => _mealItemRepository.DeleteMealItemById(m));

            // Update meal
            _mealRepository.UpsertMeal(mealId, new MealModel(meal.Id, meal.Name, meal.ConsumedAt, mealItemIds, meal.Description));
            
            // Update meal item
            meal.MealItems.ForEach(m => _mealItemRepository.UpsertMealItem(m.Id, MealItemToModel(m)));
        }

        public List<MealDto> GetMeals(DateTimeOffset start, DateTimeOffset end)
        {
            var meals = new List<MealDto>();
            var result = _mealRepository.GetMeals().Where(x => x.ConsumedAt > start && x.ConsumedAt < end).ToList();
            foreach (var meal in result)
            {
                meals.Add(MealModelToDto(meal));
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

        private MealDto MealModelToDto(MealModel mealModel)
        {
            var mealItems = new List<MealItem>();
            var mealItemModels = _mealItemRepository.GetMealItemsByIds(mealModel.MealItems);
            mealItems.AddRange(
                mealItemModels.Select(MealItemFromModel));
            var meal = new MealDto(mealModel.Id, mealModel.Name, mealModel.ConsumedAt, mealItems);
            return meal;
        }

        private MealModel MealDtoToModel(MealDto meal)
        {
            return new MealModel(
                meal.Id,
                meal.Name,
                meal.ConsumedAt,
                meal.MealItems.Select(mealItem => mealItem.Id).ToList(),
                meal.Description);
        }

        private MealItemModel MealItemToModel(MealItem mealItem)
        {
            return new MealItemModel(
                mealItem.Id,
                mealItem.Name,
                mealItem.ServingSize.ToString(),
                mealItem.ServingAmount,
                mealItem.TotalCalories,
                mealItem.Description);
        }

        private MealItem MealItemFromModel(MealItemModel model)
        {
            return new MealItem(
                    model.Id,
                    model.Name,
                    (Constants.ServingSizeOption)Enum.Parse(typeof(Constants.ServingSizeOption), model.ServingSize),
                    model.ServingAmount,
                    model.TotalCalories,
                    model.Description);
        }
    }
}
