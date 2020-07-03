using AutoMapper;
using FoodCourt.DAL;
using FoodCourt.DAL.Entities;
using FoodCourt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodCourt.Services.RestaurantService
{
    public class RestaurantServices : IRestaurantServices
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        public RestaurantServices(IUnitOfWorkFactory unitOfWorkFactory)
        {
            if (unitOfWorkFactory == null)
                throw new ArgumentNullException(nameof(unitOfWorkFactory));
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public List<RestaurantModel> GetAllRestaurants()
        {
            using (UnitOfWork unitOfWork = _unitOfWorkFactory.Create())
            {
                List<Restaurant> restaurants = unitOfWork.Restaurants.GetAll().ToList();
                return Mapper.Map<List<RestaurantModel>>(restaurants);
            }
        }

        public RestaurantModel GetRestaurantDishes(int id)
        {
            using (UnitOfWork unitOfWork = _unitOfWorkFactory.Create())
            {
                Restaurant restaurant = unitOfWork.Restaurants.GetByIdWithDishes(id);
                return Mapper.Map<RestaurantModel>(restaurant);
            }
        }
    }
}
