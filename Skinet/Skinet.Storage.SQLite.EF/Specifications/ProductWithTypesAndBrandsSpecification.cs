
using Skinet.Storage.Core.Specifications;
using Skinet.Storage.SQLite.EF.Entities;

namespace Skinet.Storage.SQLite.EF.Specifications
{
    public class ProductWithTypesAndBrandsSpecification : BaseSpecification<ProductDto>
    {
        public ProductWithTypesAndBrandsSpecification(ProductSpecParams productParams)
            : base(ProductFilterExpressionGenerator.Generate(productParams))
        {
            AddIncludes();

            if (!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;
                }
            }
            else
            {
                AddOrderBy(p => p.Name);
            }

            ApplyPaging(productParams.Skip, productParams.PageSize);
        }

        public ProductWithTypesAndBrandsSpecification(int id)
            : base(x => x.Id == id)
        {
            AddIncludes();
        }

        private void AddIncludes()
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}
