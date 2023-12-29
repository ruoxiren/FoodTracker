using FoodTracker.Data.Model;

namespace FoodTracker.Data.Repository.Interfaces
{
    public interface IMealRepository
    {
        List<MealModel> GetMeal();

        MealModel? GetMealById(Guid id);

        MealModel? GetMealByName(string name);

        void AddMeal(MealModel meal);

        void UpdateMeal(Guid mealId, MealModel meal);

        void DeleteMealById(Guid id);
    }
}
