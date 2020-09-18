using System;
using System.Linq.Expressions;

using Skinet.Storage.Core.Specifications;
using Skinet.Storage.SQLite.EF.Entities;

namespace Skinet.Storage.SQLite.EF.Specifications
{
    public static class ProductFilterExpressionGenerator
    {
        public static Expression<Func<ProductDto, bool>> Generate(ProductSpecParams productParams)
        {
            return x =>
                   (string.IsNullOrEmpty(productParams.Search) ||
                        x.Name.ToLower().Contains(productParams.Search))
                && (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId)
                && (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId);
        }
    }
}
