using FoodCourt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodCourt.Services.BasketService
{
    public interface IBasketServices
    {
        List<BasketItemModel> GetBasketItems(int userId);
        BasketItemCreate GetBasketItemCreateModel(int dishId);
        void CreateBasketItem(BasketItemCreate item,int dishId, int userId);
    }
}
