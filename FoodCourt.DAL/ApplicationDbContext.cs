using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FoodCourt.DAL.Entities;
using FoodCourt.DAL.EntitiesConfiguration.Contracts;

namespace FoodCourt.DAL
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int>
    {
        public readonly IEntityConfigurationContainer _entityConfigurationContainer;


        public ApplicationDbContext(
            DbContextOptions options,
            IEntityConfigurationContainer entityConfigurationContainer) : base(options)
        {
            _entityConfigurationContainer = entityConfigurationContainer;

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
    }
}
