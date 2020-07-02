using FoodCourt.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodCourt.DAL.EntitiesConfiguration
{
    public class DishConfiguration : BaseEntityConfiguration<Dish>
    {
        protected override void ConfigureProperties(EntityTypeBuilder<Dish> builder)
        {
            builder.Property(d => d.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Price)
                .IsRequired();

            builder.Property(d => d.Description)
               .HasMaxLength(500);

            builder.HasIndex(d => d.Name)
                .IsUnique();
        }
        protected override void ConfigureForeignKey(EntityTypeBuilder<Dish> builder)
        {
            builder.HasOne(d => d.Restaurant)
               .WithMany(r => r.Dishes)
               .HasForeignKey(d => d.RestaurantId)
               .IsRequired();

            builder.HasMany(d => d.Basket)
               .WithOne(b => b.Dish)
               .HasForeignKey(b => b.DishId)
               .IsRequired();
        }
    }
}
