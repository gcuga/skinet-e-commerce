using Skinet.Core;
using Skinet.Storage.Core;

namespace Skinet.Storage.SQLite.EF.Entities
{
    public class ProductBrandDto : BaseEntityDto, IMapToCoreEntity<ProductBrand>
    {
        public string Name { get; set; }

        public ProductBrand ToCoreEntity() => new ProductBrand(Id, Name);
    }
}