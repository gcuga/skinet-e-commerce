
using System.Security.Cryptography.X509Certificates;

using Skinet.Storage.Core.Specifications;
using Skinet.Storage.SQLite.EF.Entities;

namespace Skinet.Storage.SQLite.EF.Specifications
{
    public class ProductDtoWithTypesAndBrandsSpecification : BaseSpecification<ProductDto>
    {
        public ProductDtoWithTypesAndBrandsSpecification()
        {
            CommonConstructorBody();        }

        public ProductDtoWithTypesAndBrandsSpecification(int id)
            : base(x => x.Id == id)
        {
            CommonConstructorBody();
        }

        private void CommonConstructorBody()
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}
