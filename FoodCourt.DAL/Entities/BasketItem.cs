using System;
using System.Collections.Generic;
using System.Text;

namespace FoodCourt.DAL.Entities
{
    public class BasketItem : IEntity
    {
        public int Id { get; set; }
        public int DishesCount { get; set; }
        public decimal TotalCost { get; set; }

        public int DishId { get; set; }
        public Dish Dish { get; set; }

        public int ClientId { get; set; }
        public User Client { get; set; }
    }
}
