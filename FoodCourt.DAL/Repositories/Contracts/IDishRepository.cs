using FoodCourt.DAL.Entities;
using System.Collections.Generic;

namespace FoodCourt.DAL.Repositories.Contracts
{
    public interface IDishRepository : IRepository<Dish>
    {
        IEnumerable<Dish> GetAllByRestaurantId(int id);
    }
}
