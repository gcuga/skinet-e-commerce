using System;

namespace Skinet.Core
{
    public class Product : BaseEntityCore
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }

        public string PictureUrl { get; set; }

        public ProductType ProductType { get; set; }

        public ProductBrand ProductBrand { get; set; }

        public Product(int id,
                       string name,
                       string description,
                       decimal price,
                       string pictureUrl,
                       ProductType productType,
                       ProductBrand productBrand) : base (id)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Price = price;
            PictureUrl = pictureUrl ?? throw new ArgumentNullException(nameof(pictureUrl));
            ProductType = productType;
            ProductBrand = productBrand;
        }
    }
}
