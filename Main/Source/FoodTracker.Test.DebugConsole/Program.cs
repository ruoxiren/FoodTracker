using FoodTracker.Data.DTO;
using System.Text.Json;

namespace FoodTracker.Test.DebugConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string json = "{}";
            JsonSerializer.Deserialize<MealDto>(json);
        }
    }
}
