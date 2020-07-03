using System;
using System.Collections.Generic;
using FoodCourt.Models;
using FoodCourt.Services.RestaurantService;
using Microsoft.AspNetCore.Mvc;

namespace FoodCourt.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IRestaurantServices _restaurantServices;

        public RestaurantController(IRestaurantServices restaurantServices)
        {
            if (restaurantServices == null)
                throw new ArgumentNullException(nameof(restaurantServices));
            _restaurantServices = restaurantServices;
        }

        public IActionResult Index()
        {
            try
            {
                List<RestaurantModel> models = _restaurantServices.GetAllRestaurants();
                return View(models);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        public IActionResult GetDishes(int? id)
        {
            try
            {
                RestaurantModel restaurantDishes = _restaurantServices.GetRestaurantDishes(id.Value);
                return View(restaurantDishes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
