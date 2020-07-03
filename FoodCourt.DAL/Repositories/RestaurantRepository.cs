using FoodCourt.DAL.Entities;
using FoodCourt.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FoodCourt.DAL.Repositories
{
    public class RestaurantRepository : Repository<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(ApplicationDbContext context) : base(context)
        {
            entities = context.Restaurants;
        }

        public Restaurant GetByIdWithDishes(int id)
        {
            return entities.Include(r => r.Dishes).FirstOrDefault(r => r.Id == id);
        }
    }
}
