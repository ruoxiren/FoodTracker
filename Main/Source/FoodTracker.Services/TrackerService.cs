using FoodTracker.Data;
using FoodTracker.Data.DTO;
using FoodTracker.Data.Model;
using FoodTracker.Data.Repository.Interfaces;

namespace FoodTracker.Services
{
    public class TrackerService
    {
        private readonly IMealRepository _mealRepository;
        private readonly IRecipeRepository _recipeRepository;

        public TrackerService(IMealRepository mealRepository, IRecipeRepository recipeRepository)
        {
            _mealRepository = mealRepository;
            _recipeRepository = recipeRepository;
        }

        public List<MealDto> GetMeals(DateTimeOffset start, DateTimeOffset end)
        {
            var meals = new List<MealDto>();
            var result = _mealRepository.GetMeal().Where(x => x.ConsumedAt > start && x.ConsumedAt < end).ToList();
            foreach (var meal in result)
            {
                meals.Add(MealModelToDto(meal));
            }
            return meals;
        }

        private MealDto MealModelToDto(MealModel mealModel)
        {
            if (mealModel.Recipes != null && mealModel.Servings != null)
            {
                var recipesAndServings = new List<MealItem>();
                var total = mealModel.Recipes.Count();
                for (var i = 0; i < total; i++)
                {
                    var recipeId = mealModel.Recipes[i];
                    var servingSize = mealModel.Servings[i];
                    RecipeModel? recipeModel = _recipeRepository.GetRecipeById(recipeId);
                    if (recipeModel != null)
                    {
                        recipesAndServings.Add(new MealItem(new RecipeDto(recipeModel.Id, recipeModel.Name, recipeModel.ServingSize, recipeModel.Calories, recipeModel.Description), servingSize));
                    }
                    else
                    {
                        throw new ArgumentNullException($"{nameof(TrackerService)}: can not find recipe of id {recipeId}");
                    }
                }

                var mealDto = new MealDto(mealModel.Id, mealModel.Name, mealModel.ConsumedAt, recipesAndServings);
                return mealDto;
            }
            else if (mealModel.Calories != null)
            {
                var mealDto = new MealDto(mealModel.Name, mealModel.ConsumedAt, mealModel.Calories.Value);
                return mealDto;
            }
            else
            {
                throw new ArgumentNullException($"{nameof(TrackerService)}: both `RecipesAndServings` and `Calories` are null in {nameof(mealModel)}");
            }
        }
    }
}
