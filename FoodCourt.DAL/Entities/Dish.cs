using System;
using System.Collections.Generic;
using System.Text;

namespace FoodCourt.DAL.Entities
{
    public class Dish : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public ICollection<BasketItem> Basket { get; set; }
        //на самом деле станно делать коллекцию из одного элемента, но связь 1к1 такое себе
    }
}
