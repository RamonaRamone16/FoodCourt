using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodCourt.Models
{
    public class BasketItemCreate
    {
        public DishModel Dish { get; set; }

        [Required(ErrorMessage = "Введите количество порций")]
        [Range(1, Double.PositiveInfinity, ErrorMessage = "Количество порций не может быть отрицательным")]
        public int Count { get; set; }
    }
}
