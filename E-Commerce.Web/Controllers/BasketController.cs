using E_Commerce.Service.Services.BasketService.Dtos;
using E_Commerce.Service.Services.BasketService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Web.Controllers
{
    public class BasketController : BaseController
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerBasketDto>> GetBasketAsync(string id)
            => Ok(await _basketService.GetBasketAsync(id));

        [HttpPost]
        public async Task<ActionResult<CustomerBasketDto>> UpdateBasketAsync(CustomerBasketDto basket)
            => Ok(await _basketService.UpdateBasketAsync(basket));

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteBasketAsync(string id)
            => Ok(await _basketService.DeleteBasketAsync(id));
    }
}
