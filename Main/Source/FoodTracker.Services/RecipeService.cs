using FoodTracker.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker.Services
{
    public class RecipeService
    {
        private readonly RecipeService _recipeService;

        public RecipeService(RecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        public bool AddRecipe(RecipeDto recipe)
        {
            throw new NotImplementedException();
        }

        public RecipeDto GetRecipe(int id)
        {
            throw new NotImplementedException();
        }

        public RecipeDto GetAllRecipes()
        {
            throw new NotImplementedException();
        }

        public bool UpdateRecipe(Guid recipeId, RecipeDto recipe)
        {
            throw new NotImplementedException();
        }

        public bool RemoveRecipe(Guid recipeId)
        {
            throw new NotImplementedException();
        }
    }
}
