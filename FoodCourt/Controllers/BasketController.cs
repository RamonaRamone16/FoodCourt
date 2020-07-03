using System;
using System.Threading.Tasks;
using FoodCourt.DAL.Entities;
using FoodCourt.Models;
using FoodCourt.Services.BasketService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FoodCourt.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketServices _basketServices;
        private readonly UserManager<User> _userManager;

        public BasketController(IBasketServices basketServices, UserManager<User> userManager)
        {
            if (basketServices == null)
                throw new ArgumentNullException(nameof(basketServices));
            if (userManager == null)
                throw new ArgumentNullException(nameof(userManager));
            _userManager = userManager;
            _basketServices = basketServices;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            try
            {
                User user = await _userManager.GetUserAsync(User);
                return View(_basketServices.GetBasketItems(user.Id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create(int? dishId)
        {
            try
            {
                BasketItemCreate basketItem = _basketServices.GetBasketItemCreateModel(dishId.Value);
                return View(basketItem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateBasketItem(BasketItemCreate item, int? dishId)
        {
            try
            {
                User user = await _userManager.GetUserAsync(User);
                _basketServices.CreateBasketItem(item, dishId.Value, user.Id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
