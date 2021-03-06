﻿using Skinet.Core;
using Skinet.Storage.Core;

namespace Skinet.Storage.SQLite.EF.Entities
{
    public class ProductDto : BaseEntityDto, IMapToCoreEntity<Product>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string PictureUrl { get; set; }

        public ProductTypeDto ProductType { get; set; }

        public int ProductTypeId { get; set; }

        public ProductBrandDto ProductBrand { get; set; }

        public int ProductBrandId { get; set; }

        public Product ToCoreEntity() =>
            new Product(Id,
                        Name,
                        Description,
                        Price,
                        PictureUrl,
                        (ProductType != null) ? new ProductType(ProductTypeId, ProductType.Name) : null,
                        (ProductBrand != null) ? new ProductBrand(ProductBrandId, ProductBrand.Name) : null);
    }
}
