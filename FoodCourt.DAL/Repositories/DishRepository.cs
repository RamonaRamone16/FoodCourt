using FoodCourt.DAL.Entities;
using FoodCourt.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodCourt.DAL.Repositories
{
    public class DishRepository : Repository<Dish>, IDishRepository
    {
        public DishRepository(ApplicationDbContext context) : base(context)
        {
            entities = context.Dishes;
        }

        public IEnumerable<Dish> GetAllByRestaurantId(int id)
        {
            return entities.Where(d => d.RestaurantId == id);
        }
    }
}
