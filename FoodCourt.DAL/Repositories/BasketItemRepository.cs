using FoodCourt.DAL.Entities;
using FoodCourt.DAL.Repositories.Contracts;

namespace FoodCourt.DAL.Repositories
{
    public class BasketItemRepository : Repository<BasketItem>, IBasketItemRepository
    {
        public BasketItemRepository(ApplicationDbContext context) : base(context)
        {
            entities = context.Basket;
        }
    }
}
