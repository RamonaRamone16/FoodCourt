using FoodCourt.DAL.Repositories;
using FoodCourt.DAL.Repositories.Contracts;
using System;

namespace FoodCourt.DAL
{
    public class UnitOfWork : IDisposable
    {
        private readonly ApplicationDbContext _context;

        private bool disposed;
        public IRestaurantRepository Restaurants { get; }
        public IDishRepository Dishes { get; }
        public IBasketItemRepository Basket { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Restaurants = new RestaurantRepository(context);
            Dishes = new DishRepository(context);
            Basket = new BasketItemRepository(context);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
                _context.Dispose();

            disposed = true;
        }
        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
