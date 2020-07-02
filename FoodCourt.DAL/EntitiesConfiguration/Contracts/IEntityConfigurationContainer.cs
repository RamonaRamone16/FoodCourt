using FoodCourt.DAL.Entities;

namespace FoodCourt.DAL.EntitiesConfiguration.Contracts
{
    public interface IEntityConfigurationContainer
    {
        IEntityConfiguration<Restaurant> RestaurantConfiguration { get; set; }
        IEntityConfiguration<Dish> DishConfiguration { get; set; }
        IEntityConfiguration<BasketItem> BasketItemConfiguration { get; set; }
    }
}
