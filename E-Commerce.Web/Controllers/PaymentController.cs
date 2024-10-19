using E_Commerce.Service.Services.BasketService.Dtos;
using E_Commerce.Service.Services.PaymentService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace E_Commerce.Web.Controllers
{
    public class PaymentController : BaseController
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasketDto>> CreateOrUpdatePaymentIntent(CustomerBasketDto input)
            => Ok(await _paymentService.CreateOrUpdatePaymentIntent(input));
    }
}
