using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Skinet.Core;
using Skinet.Storage.SQLite.EF.Context;
using Skinet.Storage.SQLite.EF.Entities;
using Skinet.Storage.Core;
using System;

namespace Skinet.Storage.SQLite.EF
{
    public class SQLiteProductStorage : IProductStorage
    {
        private readonly GenericStorage<ProductDto, StorageContext> _productStorage;
        private readonly GenericStorage<ProductTypeDto, StorageContext> _productTypeStorage;
        private readonly GenericStorage<ProductBrandDto, StorageContext> _productBrandStorage;

        public SQLiteProductStorage(GenericStorage<ProductDto, StorageContext> productStorage,
            GenericStorage<ProductTypeDto, StorageContext> productTypeStorage,
            GenericStorage<ProductBrandDto, StorageContext> productBrandStorage
            //StorageContext context
            )
        {
            _productStorage = productStorage;
            _productTypeStorage = productTypeStorage;
            _productBrandStorage = productBrandStorage;
            //_productStorage = new GenericStorage<ProductDto, StorageContext>(context);
            //_productTypeStorage = new GenericStorage<ProductTypeDto, StorageContext>(context);
            //_productBrandStorage = new GenericStorage<ProductBrandDto, StorageContext>(context);
        }

        public async Task<Product> GetProductAsync(int id)
        {
            ProductDto productDto = await _productStorage.GetByIdAsync(id);

            return productDto?.ToCoreEntity();
        }

        public async Task<ProductBrand> GetProductBrandAsync(int id)
        {
            ProductBrandDto productBrandDto = await _productBrandStorage.GetByIdAsync(id);

            return productBrandDto?.ToCoreEntity();
        }

        public async Task<ProductType> GetProductTypeAsync(int id)
        {
            ProductTypeDto productTypeDto = await _productTypeStorage.GetByIdAsync(id);

            return productTypeDto?.ToCoreEntity();
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return (await _productStorage.ListAllAsync())
                .Select(p => p.ToCoreEntity())
                .ToList();
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return (await _productBrandStorage.ListAllAsync())
                .Select(b => b.ToCoreEntity())
                .ToList();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return (await _productTypeStorage.ListAllAsync())
                .Select(t => t.ToCoreEntity())
                .ToList();
        }
    }
}
