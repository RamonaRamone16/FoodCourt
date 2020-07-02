using FoodCourt.DAL.Entities;
using FoodCourt.DAL.Repositories.Contracts;

namespace FoodCourt.DAL.Repositories
{
    public class RestaurantRepository : Repository<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(ApplicationDbContext context) : base(context)
        {
            entities = context.Restaurants;
        }
    }
}
