using FoodTracker.Data.DTO;
using FoodTracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodTracker.Host.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoodTrackerController : ControllerBase
    {
        private readonly MealService _foodTrackerService;
        private readonly ILogger<FoodTrackerController> _logger;
        public FoodTrackerController(MealService trackerService, ILogger<FoodTrackerController> logger)
        {
            _foodTrackerService = trackerService;
            _logger = logger;
        }

        [HttpGet(Name = "GetMeals")]
        public IEnumerable<MealDto> GetMeals(DateTimeOffset start, DateTimeOffset end)
        {
            var result = _foodTrackerService.GetMeals(start, end);
            return result.ToList();
        }
    }
}
