using FoodCourt.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodCourt.DAL.EntitiesConfiguration
{
    public class BasketItemConfiguration : BaseEntityConfiguration<BasketItem>
    {
        protected override void ConfigureProperties(EntityTypeBuilder<BasketItem> builder)
        {
            builder.Property(b => b.DishesCount)
                .IsRequired();

            builder.Property(b => b.TotalCost)
               .IsRequired();
        }
        protected override void ConfigureForeignKey(EntityTypeBuilder<BasketItem> builder)
        {
            builder.HasOne(b => b.Dish)
               .WithMany(d => d.Basket)
               .HasForeignKey(b => b.DishId)
               .IsRequired();

            builder.HasOne(b => b.Client)
               .WithMany(u => u.Basket)
               .HasForeignKey(b => b.ClientId)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired();
        }
    }
}
