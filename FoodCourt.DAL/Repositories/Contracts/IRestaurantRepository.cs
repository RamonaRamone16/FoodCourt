using FoodCourt.DAL.Entities;

namespace FoodCourt.DAL.Repositories.Contracts
{
    public interface IRestaurantRepository : IRepository<Restaurant>
    {
        Restaurant GetByIdWithDishes(int id);
    }
}
