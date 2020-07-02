using System.Collections.Generic;

namespace FoodCourt.DAL.Entities
{
    public class Restaurant : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Dish> Dishes { get; set; }
    }
}
