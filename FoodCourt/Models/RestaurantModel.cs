using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodCourt.Models
{
    public class RestaurantModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<DishModel> Dishes { get; set; }
    }
}
