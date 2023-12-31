using FoodTracker.Data.DTO;
using FoodTracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodTracker.Host.WebApi.Controllers
{
    [ApiController]
    [Route("meals")]
    public class MealsController : ControllerBase
    {
        private readonly MealService _mealService;
        private readonly ILogger<MealsController> _logger;
        public MealsController(MealService trackerService, ILogger<MealsController> logger)
        {
            _mealService = trackerService;
            _logger = logger;
        }

        [HttpGet(Name = "GetMeals")]
        public IEnumerable<MealDto> GetMeals(DateTimeOffset startDateTime, DateTimeOffset endDateTime)
        {
            var result = _mealService.GetMeals(startDateTime, endDateTime);
            return result.ToList();
        }

        [HttpPost(Name = "PostMeals")]
        public ActionResult<MealDto> PostMeals(MealDto meal)
        {
            _mealService.AddMeal(meal);
            return CreatedAtAction(nameof(PostMeals), new { id = meal.Id }, meal); ;
        }
    }
}
