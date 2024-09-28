using E_Commerce.Data.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repository.Specification.ProductSpecs
{
    public class ProductWithSpecifications : BaseSpecification<Product>
    {
        public ProductWithSpecifications(ProductSpecification specs)
            : base(product => (!specs.BrandId.HasValue || product.BrandId == specs.BrandId.Value) &&
                                    (!specs.TypeId.HasValue || product.TypeId == specs.TypeId.Value)
                )
        {
            AddInclude(x => x.Brand);
            AddInclude(x => x.Type);

        }
    }
}
