using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FoodCourt.DAL.Entities;
using FoodCourt.DAL.EntitiesConfiguration.Contracts;

namespace FoodCourt.DAL
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int>
    {
        public readonly IEntityConfigurationContainer _entityConfigurationContainer;

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<BasketItem> Basket { get; set; }

        public ApplicationDbContext(
            DbContextOptions options,
            IEntityConfigurationContainer entityConfigurationContainer) : base(options)
        {
            _entityConfigurationContainer = entityConfigurationContainer;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity(_entityConfigurationContainer.RestaurantConfiguration.ProvideConfigurationAction());
            builder.Entity(_entityConfigurationContainer.DishConfiguration.ProvideConfigurationAction());
            builder.Entity(_entityConfigurationContainer.BasketItemConfiguration.ProvideConfigurationAction());
        }
    }
}
