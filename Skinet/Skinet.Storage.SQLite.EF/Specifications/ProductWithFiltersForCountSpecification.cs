using Skinet.Storage.Core.Specifications;
using Skinet.Storage.SQLite.EF.Entities;

namespace Skinet.Storage.SQLite.EF.Specifications
{
    class ProductWithFiltersForCountSpecification : BaseSpecification<ProductDto>
    {
        public ProductWithFiltersForCountSpecification(ProductSpecParams productParams)
            : base(ProductFilterExpressionGenerator.Generate(productParams))
        {
        }
    }
}
