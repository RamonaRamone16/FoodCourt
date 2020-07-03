using FoodCourt.DAL.Entities;
using FoodCourt.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FoodCourt.DAL.Repositories
{
    public class BasketItemRepository : Repository<BasketItem>, IBasketItemRepository
    {
        public BasketItemRepository(ApplicationDbContext context) : base(context)
        {
            entities = context.Basket;
        }

        public IEnumerable<BasketItem> GetAllByUserId(int clientId)
        {
            return entities.Where(b => b.ClientId == clientId).Include(b => b.Dish)
                .ThenInclude(b => b.Restaurant);
        }
    }
}
