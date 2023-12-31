using FoodTracker.Data.Model;
using FoodTracker.Data.Repository.Interfaces;

namespace FoodTracker.Data.Repository.InMemory
{
    public class InMemoryMealItemRepository : IMealItemRepository
    {
        public static readonly List<MealItemModel> InMemoryMealItems = new List<MealItemModel>()
        {
            new MealItemModel(Guid.NewGuid(), "Fish", "PerMeal", 1, 200),
            new MealItemModel(Guid.NewGuid(), "Egg", "PerCount", 2, 150),
            new MealItemModel(Guid.NewGuid(), "White Rice", "Per100G", (decimal)0.5, 200),
            new MealItemModel(Guid.NewGuid(), "Dim Sum", "PerMeal", 1, 1000),
        };

        public void AddMealItem(MealItemModel mealItem)
        {
            if (mealItem == null)
            {
                throw new ArgumentNullException(nameof(mealItem));
            }

            if (mealItem.Id == Guid.Empty)
            {
                mealItem.Id = Guid.NewGuid();
            }

            InMemoryMealItems.Add(mealItem);
        }

        public void AddMealItems(List<MealItemModel> mealItemLists)
        {
            mealItemLists.ForEach(AddMealItem);
        }

        public void DeleteMealItemById(Guid id)
        {
            InMemoryMealItems.RemoveAll(m => m.Id == id);
        }

        public MealItemModel? GetMealItemById(Guid id)
        {
            var result = InMemoryMealItems.FirstOrDefault(m => m.Id == id);
            return result;
        }

        public MealItemModel? GetMealItemByName(string name)
        {
            var result = InMemoryMealItems.FirstOrDefault(x => x.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
            return result;
        }

        public List<MealItemModel> GetMealItemsByIds(List<Guid> ids)
        {
            if (ids == null)
            {
                throw new ArgumentNullException("GetMealItemByIds failed for null id");
            }
            var result = new List<MealItemModel>();
            ids.ForEach(i => 
                {
                    var mealItem = GetMealItemById(i);
                    if (mealItem != null)
                    {
                        result.Add(mealItem);
                    }
                    else
                    {
                        throw new ArgumentNullException($"Can not find meal Item of id: {i}");
                    }
                });
            return result;
        }

        public void UpsertMealItem(Guid id, MealItemModel mealItem)
        {
            var result = InMemoryMealItems.FirstOrDefault(m => m.Id == id);

            if (result != null)
            {
                result.Name = mealItem.Name;
                result.ServingSize = mealItem.ServingSize;
                result.ServingAmount = mealItem.ServingAmount;
                result.TotalCalories = mealItem.TotalCalories;
                result.Description = mealItem.Description;
            }
            else
            {
                AddMealItem(mealItem);
            }
        }
    }
}
