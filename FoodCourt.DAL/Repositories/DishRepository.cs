using FoodCourt.DAL.Entities;
using FoodCourt.DAL.Repositories.Contracts;
using System;
namespace FoodCourt.DAL.Repositories
{
    public class DishRepository : Repository<Dish>, IDishRepository
    {
        public DishRepository(ApplicationDbContext context) : base(context)
        {
            entities = context.Dishes;
        }
    }
}
