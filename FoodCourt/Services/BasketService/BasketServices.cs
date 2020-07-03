using AutoMapper;
using FoodCourt.DAL;
using FoodCourt.DAL.Entities;
using FoodCourt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodCourt.Services.BasketService
{
    public class BasketServices : IBasketServices
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        public BasketServices(IUnitOfWorkFactory unitOfWorkFactory)
        {
            if (unitOfWorkFactory == null)
                throw new ArgumentNullException(nameof(unitOfWorkFactory));
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public BasketItemCreate GetBasketItemCreateModel(int dishId)
        {
            using (UnitOfWork unitOfWork = _unitOfWorkFactory.Create())
            {
                BasketItemCreate basketItem = new BasketItemCreate();
                Dish dish = unitOfWork.Dishes.GetById(dishId);
                basketItem.Dish = Mapper.Map<DishModel>(dish);
                return basketItem;
            }
        }

        public List<BasketItemModel> GetBasketItems(int userId)
        {
            using (UnitOfWork unitOfWork = _unitOfWorkFactory.Create())
            {
                List<BasketItem> basket = unitOfWork.Basket.GetAllByUserId(userId).ToList();

                List<BasketItemModel> basketModel = Mapper.Map<List<BasketItemModel>>(basket);
                for (int i = 0; i< basketModel.Count; i++)
                {
                    basketModel[i].Dish = Mapper.Map<DishModel>(basket[i].Dish);
                }
                basketModel = basketModel.ByRestouranName();

                return basketModel;
            }
        }

        public void CreateBasketItem(BasketItemCreate item, int dishId, int userId)
        {
            using (UnitOfWork unitOfWork = _unitOfWorkFactory.Create())
            {
                BasketItem basketItem = new BasketItem();
                Dish dish = unitOfWork.Dishes.GetById(dishId);

                basketItem.ClientId = userId;
                basketItem.DishId = dishId;

                List<BasketItem> basketItems = unitOfWork.Basket.GetAllByUserId(userId).ToList();

                if (basketItems.Where(b => b.DishId == dishId).Any())
                {
                    basketItem = basketItems.FirstOrDefault(b => b.DishId == dishId);
                    basketItem.DishesCount += item.Count;
                    basketItem.TotalCost += dish.Price * item.Count;
                    unitOfWork.Basket.Update(basketItem);
                }
                else
                {
                    basketItem.DishesCount = item.Count;
                    basketItem.TotalCost = dish.Price * item.Count;
                    unitOfWork.Basket.Create(basketItem);
                }
            }
        }
    }
}
