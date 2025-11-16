using E_Commerce.Repository.Interfaces;
using E_Commerce.Repository.Repository;
using E_Commerce.Service.Services.ProductServices.Dtos;
using E_Commerce.Service.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;
using E_Commerce.Service.HandleResponses;
using E_Commerce.Service.Services.CacheService;
using E_Commerce.Repository.Basket;
using E_Commerce.Service.Services.BasketService;
using E_Commerce.Service.Services.BasketService.Dtos;
using E_Commerce.Service.Services.UserService;
using E_Commerce.Service.Services.TokenService;
using E_Commerce.Service.Services.OrderService;
using E_Commerce.Service.Services.PaymentService;

namespace E_Commerce.Web.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICacheService, CacheService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddAutoMapper(typeof(ProductProfile));
            services.AddAutoMapper(typeof(BasketProfile));

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                        .Where(model => model.Value.Errors.Count > 0)
                        .SelectMany(model => model.Value.Errors)
                        .Select(error => error.ErrorMessage)
                        .ToList();

                    var errorResponse = new ValidationErrorResponse
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorResponse);
                };
            });
            return services;
        }
    }
}
