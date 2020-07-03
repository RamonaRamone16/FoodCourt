using AutoMapper;
using FoodCourt.DAL.Entities;
using FoodCourt.Models;

namespace FoodCourt
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            RestaurantToRestaurantModelMap();
            BasketItemToBasketItemModelMap();
            DishItemToDishModelMap();
            BasketItemCreateToBasketItemMap();
        }

        public void RestaurantToRestaurantModelMap()
        {
            CreateMap<Restaurant, RestaurantModel>();
        }

        public void BasketItemToBasketItemModelMap()
        {
            CreateMap<BasketItem, BasketItemModel>()
                .ForMember(to => to.RestaurantName, from => from.MapFrom(t => t.Dish.Restaurant.Name))
                .ForMember(to => to.RestaurantId, from => from.MapFrom(t => t.Dish.Restaurant.Id));
        }

        public void DishItemToDishModelMap()
        {
            CreateMap<Dish, DishModel>();
        }

        public void BasketItemCreateToBasketItemMap()
        {
            CreateMap<BasketItemCreate, BasketItem>()
                .ForMember(to => to.DishId, from => from.MapFrom(t => t.Dish.Id));
        }
    }
}
