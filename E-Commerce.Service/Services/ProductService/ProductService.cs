using E_Commerce.Data.Entities;
using E_Commerce.Repository.Interfaces;
using E_Commerce.Service.Services.ProductService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Service.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllBrandsAsync()
        {
            var brands = await _unitOfWork.Repository<ProductBrand, int>().GetAllAsNoTrackingAsync();
            var mappedBrands = brands.Select(x => new BrandTypeDetailsDto() 
            { 
                Id = x.Id,
                Name = x.Name,
                CreatedAt = x.CreateddAt,
            }).ToList();

            return mappedBrands;
        }

        public async Task<IReadOnlyList<ProductDetailsDto>> GetAllProductsAsync()
        {
            var products = await _unitOfWork.Repository<Product, int>().GetAllAsNoTrackingAsync();
            var mappedProducts = products.Select(x => new ProductDetailsDto() 
            { 
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                PictureUrl = x.PictureUrl,
                Price = x.Price,
                CreatedAt = x.CreateddAt,
                BrandName = x.Brand.Name,
                TypeName = x.Type.Name,
            }).ToList();

            return mappedProducts;
        }

        public async Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllTypesAsync()
        {
            var types = await _unitOfWork.Repository<ProductType, int>().GetAllAsNoTrackingAsync();
            var mappedTypes = types.Select(x => new BrandTypeDetailsDto() 
            { 
                Id = x.Id,
                Name = x.Name,
                CreatedAt = x.CreateddAt,
            }).ToList();

            return mappedTypes;
        }

        public async Task<ProductDetailsDto> GetProductByIdAsync(int? productId)
        {
            if (productId is null)
                throw new Exception("Id is null");

            var product = await _unitOfWork.Repository<Product, int>().GetByIdAsync(productId.Value);
            if (product is null)
                throw new Exception("Product Not Found");

            var mappedProduct = new ProductDetailsDto()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                PictureUrl = product.PictureUrl,
                Price = product.Price,
                CreatedAt = product.CreateddAt,
                BrandName = product.Brand.Name,
                TypeName = product.Type.Name,
            };

            return mappedProduct;
        }
    }
}
