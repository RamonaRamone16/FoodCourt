using FoodCourt.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodCourt.DAL.EntitiesConfiguration
{
    public class UserConfiguration : BaseEntityConfiguration<User>
    {
        protected override void ConfigureProperties(EntityTypeBuilder<User> builder)
        {
        }
        protected override void ConfigureForeignKey(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(u => u.Basket)
               .WithOne(b => b.Client)
               .HasForeignKey(b => b.ClientId)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired();
        }
    }
}
