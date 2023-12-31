using FoodTracker.Data.DTO;
using FoodTracker.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker.Data.Repository.Extensions
{
    public static class RecipeExtensions
    {
        public static RecipeModel ToModel(this RecipeDto recipe)
        {
            return new RecipeModel(recipe.Id, recipe.Name, recipe.ServingSize.ToString(), recipe.Calories, recipe.Description);
        }

        public static RecipeDto ToDto(this RecipeModel recipe)
        {
            return new RecipeDto(recipe.Id, recipe.Name, recipe.ServingSize, recipe.Calories, recipe.Description);
        }
    }
}
