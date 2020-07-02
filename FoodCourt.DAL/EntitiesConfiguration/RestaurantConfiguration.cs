using FoodCourt.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodCourt.DAL.EntitiesConfiguration
{
    public class RestaurantConfiguration : BaseEntityConfiguration<Restaurant>
    {
        protected override void ConfigureProperties(EntityTypeBuilder<Restaurant> builder)
        {
            builder.Property(r => r.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(r => r.Description)
               .HasMaxLength(500);

            builder.HasIndex(r => r.Name)
                .IsUnique();
        }
        protected override void ConfigureForeignKey(EntityTypeBuilder<Restaurant> builder)
        {
            builder.HasMany(r => r.Dishes)
               .WithOne(d => d.Restaurant)
               .HasForeignKey(d => d.RestaurantId)
               .IsRequired();
        }

    }
}
