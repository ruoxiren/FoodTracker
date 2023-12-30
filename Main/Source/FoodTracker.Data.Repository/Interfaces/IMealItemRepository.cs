using FoodTracker.Data.Model;

namespace FoodTracker.Data.Repository.Interfaces
{
    public interface IMealItemRepository
    {
        List<MealItemModel> GetMealItemsByIds(List<Guid> ids);

        MealItemModel? GetMealItemById(Guid id);

        MealItemModel? GetMealItemByName(string name);

        void AddMealItem(MealItemModel mealItem);

        void AddMealItems(List<MealItemModel> mealItems);

        void UpsertMealItem(Guid id, MealItemModel mealItem);

        void DeleteMealItemById(Guid id);
    }
}
