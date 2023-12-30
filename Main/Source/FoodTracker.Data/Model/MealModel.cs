namespace FoodTracker.Data.Model
{
    public class MealModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTimeOffset ConsumedAt { get; set; }

        public List<Guid> MealItems { get; set; }

        public string? Description { get; set; }

        public MealModel(Guid id, string name, DateTimeOffset consumedAt, List<Guid> mealItems, string? description = default)
        {
            Id = id;
            Name = name;
            ConsumedAt = consumedAt;
            MealItems = mealItems;
            Description = description;
        }

        public MealModel(MealModel mealModel)
        {
            Id = mealModel.Id;
            Name = mealModel.Name;
            ConsumedAt = mealModel.ConsumedAt;
            MealItems = new List<Guid>(mealModel.MealItems);
            Description = mealModel.Description;
        }
    }
}
