using FoodTracker.Data.Model;
using FoodTracker.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FoodTracker.Data.Repository.InMemory
{
    public class InMemoryRecipeRepository : IRecipeRepository
    {
        private static readonly List<RecipeModel> recipes = new List<RecipeModel>()
        {
            new(Guid.NewGuid(), "Cheese Cake", "PerServing", 400, "Sugar and oil"),
            new(Guid.NewGuid(), "Coke","PerCup", 150, "Sugar"),
        };
        public void AddRecipe(RecipeModel recipe)
        {
            if (recipe == null)
            {
                throw new ArgumentNullException(nameof(recipe));
            }
            
            if (recipe.Id == Guid.Empty)
            {
                recipe.Id = Guid.NewGuid();
            }

            recipes.Add(recipe);
        }

        public void DeleteRecipeById(Guid id)
        {
            recipes.RemoveAll(x => x.Id == id);
        }

        public RecipeModel? GetRecipeById(Guid id)
        {
            var result = recipes.FirstOrDefault(x => x.Id == id);
            return result;
        }

        public RecipeModel? GetRecipeByName(string name)
        {
            var result = recipes.FirstOrDefault(x => x.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
            return result;
        }

        public List<RecipeModel> GetRecipe()
        {
            var list = new List<RecipeModel>();
            recipes.ForEach(x => list.Add(new(x)));
            return list;
        }
        public void UpdateRecipe(Guid recipeId, RecipeModel recipe)
        {
            var result = recipes.FirstOrDefault(x => x.Id == recipeId);

            if (result != null)
            {
                result.Name = recipe.Name;
                result.Calories = recipe.Calories;
                result.ServingSize = recipe.ServingSize;
                result.Description = recipe.Description;
            }
            else
            {
                throw new ArgumentNullException(nameof(recipe));
            }
        }
    }
}
