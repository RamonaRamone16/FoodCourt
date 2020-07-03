using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FoodCourt.DAL.EntitiesConfiguration.Contracts;
using FoodCourt.DAL.EntitiesConfiguration;
using FoodCourt.DAL.Entities;
using AutoMapper;
using FoodCourt.DAL;
using Microsoft.EntityFrameworkCore.Internal;
using FoodCourt.Services.RestaurantService;
using FoodCourt.Services.BasketService;

namespace FoodCourt
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("MainConnection");
            var optionBuilder = new DbContextOptionsBuilder();
            optionBuilder.UseSqlServer(connectionString);

            services.AddScoped<IEntityConfigurationContainer>(sp => new EntityConfigurationContainer());

            services.AddDbContext<ApplicationDbContext>(builder =>
            {
                builder.UseSqlServer(connectionString);
            }
            );

            services.AddSingleton<IApplicationDbContextFactory>(
                sp => new ApplicationDbContextFactory(optionBuilder.Options, new EntityConfigurationContainer()));

            services.AddSingleton<IUnitOfWorkFactory, UnitOfWorkFactory>();

            services.AddSingleton<IRestaurantServices, RestaurantServices>();
            services.AddSingleton<IBasketServices, BasketServices>();

            Mapper.Initialize(c => c.AddProfile(new MappingProfile()));
            services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
