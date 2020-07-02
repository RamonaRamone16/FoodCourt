namespace FoodCourt.DAL
{
    public interface IApplicationDbContextFactory
    {
        ApplicationDbContext Create();
    }
}
