using FoodTracker.Data.Constants;
using FoodTracker.Data.DTO;
using FoodTracker.Data.Model;
using FoodTracker.Data.Repository.Interfaces;
namespace FoodTracker.Data.Repository.Extensions
{
    public static class MealExtensions
    {
        public static MealDto ToDto(this MealModel mealModel, IMealItemRepository mealItemRepository)
        {
            var mealItems = new List<MealItem>();
            var mealItemModels = mealItemRepository.GetMealItemsByIds(mealModel.MealItems);
            mealItems.AddRange(
                mealItemModels.Select(FromModel));
            var meal = new MealDto(mealModel.Id, mealModel.Name, mealModel.ConsumedAt, mealItems);
            return meal;
        }

        public static MealModel ToModel(this MealDto meal)
        {
            return new MealModel(
                meal.Id,
                meal.Name,
                meal.ConsumedAt,
                meal.MealItems.Select(mealItem => mealItem.Id).ToList(),
                meal.Description);
        }

        public static MealItemModel ToModel(this MealItem mealItem)
        {
            return new MealItemModel(
                mealItem.Id,
                mealItem.Name,
                mealItem.ServingSize.ToString(),
                mealItem.ServingAmount,
                mealItem.TotalCalories,
                mealItem.Description);
        }

        public static MealItem FromModel(this MealItemModel model)
        {
            return new MealItem(
                model.Id,
                model.Name,
                (ServingSizeOption)Enum.Parse(typeof(ServingSizeOption), model.ServingSize),
                model.ServingAmount,
                model.TotalCalories,
                model.Description);
        }
    }
}
