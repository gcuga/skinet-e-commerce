using Skinet.Core;

namespace Skinet.Storage.SQLite.EF.Entities
{
    public class ProductBrandDto : BaseEntityDto
    {
        public string Name { get; set; }

        public ProductBrand ToProductBrand() => new ProductBrand(Id, Name);
    }
}