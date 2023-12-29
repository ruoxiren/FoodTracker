namespace FoodTracker.Data.Model
{
    public class RecipeModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string ServingSize { get; set; }

        public decimal Calories { get; set; }

        public string? Description { get; set; }

        public RecipeModel(RecipeModel recipeModel)
        {
            Id = recipeModel.Id;
            Name = recipeModel.Name;
            ServingSize = recipeModel.ServingSize;
            Calories = recipeModel.Calories;
            Description = recipeModel.Description;
        }

        public RecipeModel(Guid recipeId, string name, string servingSize, decimal calories, string description = "")
        {
            Id = recipeId;
            Name = name;
            ServingSize = servingSize;
            Calories = calories;
            Description = description;
        }
    }
}
