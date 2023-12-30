using FoodTracker.Data.Model;

namespace FoodTracker.Data.Repository.Interfaces
{
    public interface IMealRepository
    {
        List<MealModel> GetMeals();

        MealModel? GetMealById(Guid id);

        MealModel? GetMealByName(string name);

        void AddMeal(MealModel meal);

        void UpsertMeal(Guid id, MealModel meal);

        void DeleteMealById(Guid id);
    }
}
