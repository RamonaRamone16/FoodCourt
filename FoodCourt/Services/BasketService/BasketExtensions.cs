using FoodCourt.DAL.Entities;
using FoodCourt.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodCourt.Services.BasketService
{
    public static class BasketExtensions
    {
        public static List<BasketItemModel> ByRestouranName(this List<BasketItemModel> basketItems)
        {
            for (int i = 0; i < basketItems.Count; i++)
            {
                for (int j = 1; j < basketItems.Count; j++)
                {
                    if (basketItems[j-1].RestaurantId > basketItems[j].RestaurantId)
                    {
                        var temp = basketItems[j-1];
                        basketItems[j-1] = basketItems[j];
                        basketItems[j] = temp;
                    }
                }
            }
            return basketItems;
        }
    }
}
