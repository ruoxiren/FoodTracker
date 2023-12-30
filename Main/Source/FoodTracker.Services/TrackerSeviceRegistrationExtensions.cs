using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTracker.Data.Repository.InMemory;
using FoodTracker.Data.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FoodTracker.Services
{
    public static class TrackerSeviceRegistrationExtensions
    {
        public static IServiceCollection RegisterTrackerService(this IServiceCollection services)
        {
            services.AddSingleton<IMealRepository, InMemoryMealRepository>();
            services.AddSingleton<IMealItemRepository, InMemoryMealItemRepository>();
            services.AddSingleton<IRecipeRepository, InMemoryRecipeRepository>();

            services.AddSingleton<MealService>();
            services.AddSingleton<RecipeService>();
            return services;
        }
    }
}
