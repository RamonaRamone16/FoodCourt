using FoodCourt.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FoodCourt.DAL.EntitiesConfiguration.Contracts
{
    public interface IEntityConfiguration<T> where T : class, IEntity
    {
        Action<EntityTypeBuilder<T>> ProvideConfigurationAction();
    }
}
