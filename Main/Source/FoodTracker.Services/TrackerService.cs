using FoodTracker.Data.DTO;
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

        public List<MealDto> GetMeals()
        {
            
        }
    }
}
