using FoodTracker.Data.Model;

namespace FoodTracker.Data.Repository.Interfaces
{
    public interface IRecipeRepository
    {
        List<RecipeModel> GetRecipe();

        RecipeModel? GetRecipeById(Guid id);

        RecipeModel? GetRecipeByName(string name);

        void AddRecipe(RecipeModel recipe);

        void UpdateRecipe(Guid id, RecipeModel recipe);

        void DeleteRecipeById(Guid id);
    }
}
