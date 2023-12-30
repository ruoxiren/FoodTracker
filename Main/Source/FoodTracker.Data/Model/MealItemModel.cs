using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker.Data.Model
{
    public class MealItemModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string ServingSize { get; set; }

        public decimal ServingAmount { get; set; }

        public decimal TotalCalories { get; set; }

        public string? Description { get; set; }

        public MealItemModel(Guid id, string name, string servingSize, decimal servingAmount, decimal totalCalories, string? description = default)
        {
            Id = id;
            Name = name;
            ServingSize = servingSize;
            ServingAmount = servingAmount;
            TotalCalories = totalCalories;
            Description = description;
        }
    }
}
