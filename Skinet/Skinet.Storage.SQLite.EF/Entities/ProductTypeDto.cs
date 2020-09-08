using Skinet.Core;
using Skinet.Storage.Core;

namespace Skinet.Storage.SQLite.EF.Entities
{
    public class ProductTypeDto : BaseEntityDto, IMapToCoreEntity<ProductType>
    {
        public string Name { get; set; }

        public ProductType ToCoreEntity() => new ProductType(Id, Name);
    }
}