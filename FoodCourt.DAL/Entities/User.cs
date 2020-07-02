using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace FoodCourt.DAL.Entities
{
    public class User : IdentityUser<int>, IEntity
    {
        public ICollection<BasketItem> Basket { get; set; }
    }
}
