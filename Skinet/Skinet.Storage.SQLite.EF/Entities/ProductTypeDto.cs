using Skinet.Core;

namespace Skinet.Storage.SQLite.EF.Entities
{
    public class ProductTypeDto : BaseEntityDto
    {
        public string Name { get; set; }

        public ProductType ToProductType() => new ProductType(Id, Name);
    }
}