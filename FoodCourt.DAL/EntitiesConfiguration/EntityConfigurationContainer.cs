using FoodCourt.DAL.Entities;
using FoodCourt.DAL.EntitiesConfiguration.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodCourt.DAL.EntitiesConfiguration
{
    public class EntityConfigurationContainer : IEntityConfigurationContainer
    {
        public IEntityConfiguration<Restaurant> RestaurantConfiguration { get; set; }
        public IEntityConfiguration<Dish> DishConfiguration { get; set; }
        public IEntityConfiguration<BasketItem> BasketItemConfiguration { get; set; }
        public EntityConfigurationContainer()
        {
            RestaurantConfiguration = new RestaurantConfiguration();
            DishConfiguration = new DishConfiguration();
            BasketItemConfiguration = new BasketItemConfiguration();
        }

    }
}
