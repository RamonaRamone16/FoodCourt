using FoodCourt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodCourt.Services.RestaurantService
{
    public interface IRestaurantServices
    {
        List<RestaurantModel> GetAllRestaurants();
        RestaurantModel GetRestaurantDishes(int id);
    }
}
