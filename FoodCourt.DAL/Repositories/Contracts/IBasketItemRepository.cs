using FoodCourt.DAL.Entities;
using System.Collections.Generic;

namespace FoodCourt.DAL.Repositories.Contracts
{
    public interface IBasketItemRepository : IRepository<BasketItem>
    {
        IEnumerable<BasketItem> GetAllByUserId(int clientId);
    }
}
