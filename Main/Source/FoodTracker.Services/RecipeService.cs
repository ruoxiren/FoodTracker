using FoodTracker.Data.DTO;
using FoodTracker.Data.Repository.Extensions;
using FoodTracker.Data.Repository.Interfaces;

namespace FoodTracker.Services
{
    public class RecipeService
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipeService(IRecipeRepository recipeService)
        {
            _recipeRepository = recipeService;
        }

        public void AddRecipe(RecipeDto recipe)
        {
            _recipeRepository.AddRecipe(recipe.ToModel());
        }

        public RecipeDto GetRecipe(Guid id)
        {
            var recipe = _recipeRepository.GetRecipeById(id);
            if (recipe == null)
            {
                throw new ArgumentNullException(nameof(recipe));
            }
            return recipe.ToDto();
        }

        public List<RecipeDto> GetAllRecipes()
        {
            var recipe = _recipeRepository.GetRecipe();
            if (recipe == null)
            {
                throw new ArgumentNullException(nameof(recipe));
            }
            return recipe.Select(x => x.ToDto()).ToList();
        }

        public void UpdateRecipe(Guid recipeId, RecipeDto recipe)
        {
            _recipeRepository.UpdateRecipe(recipeId, recipe.ToModel());
        }

        public void RemoveRecipe(Guid recipeId)
        {
            _recipeRepository.DeleteRecipeById(recipeId);
        }
    }
}
