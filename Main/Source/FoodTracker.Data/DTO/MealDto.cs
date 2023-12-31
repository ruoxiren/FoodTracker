using System.Text.Json.Serialization;

namespace FoodTracker.Data.DTO
{
    public class MealDto
    {
        [JsonPropertyName("Id")]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTimeOffset ConsumedAt { get; set; }

        public List<MealItem> MealItems { get; set; }

        public decimal TotalCalories { get; set; }

        public string? Description { get; set; }

        [JsonConstructor]
        public MealDto(Guid id, string mealName, DateTimeOffset consumedAt, List<MealItem> mealItems, string? description = default)
        {
            if (mealItems == null)
            {
                throw new ArgumentNullException(nameof(mealItems));
            }
            Id = id;
            Name = mealName;
            ConsumedAt = consumedAt;
            MealItems = mealItems;
            TotalCalories = mealItems.Sum(x => x.TotalCalories);
            Description = description;
        }

        public override string ToString()
        {
            return
                $"Meal Id: {Id}, Meal Name: {Name}, Time: {ConsumedAt}, Total Calories: {TotalCalories}, mealItems: {(MealItems != null ? string.Join(", ", MealItems.Select(o => o.ToString())) : "null")}, Description: {Description}";
        }
    }
}