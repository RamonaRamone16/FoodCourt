using System.Collections.Generic;

namespace FoodCourt.Models
{
    public class RestaurantDishesModel
    {
        public int RestaurantId { get; set; }
        public RestaurantModel Restaurant { get; set; }
        public List<DishModel> Dishes { get; set; }
    }
}
