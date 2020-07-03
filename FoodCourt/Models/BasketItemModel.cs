using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodCourt.Models
{
    public class BasketItemModel
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public DishModel Dish { get; set; }
        public int DishesCount { get; set; }
        public decimal TotalCost { get; set; }
    }
}
