using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Skinet.Core;
using Skinet.Storage.SQLite.EF.Context;
using Skinet.Storage.SQLite.EF.Entities;

namespace Skinet.Storage.SQLite.EF
{
    public class SQLiteProductStorage : IProductStorage
    {
        private readonly StorageContext _context;

        public SQLiteProductStorage(StorageContext context)
        {
            _context = context;
        }

        public async Task<Product> GetProductAsync(int id)
        {
            ProductDto productDto = await _context
                .Products
                .Include(p => p.ProductType)
                .Include(p => p.ProductBrand)
                .FirstOrDefaultAsync(p => p.Id == id);

            return productDto?.ToProduct();
        }

        public async Task<ProductBrand> GetProductBrandAsync(int id)
        {
            ProductBrandDto productBrandDto = await _context
                .ProductBrands
                .FindAsync(id);

            return productBrandDto?.ToProductBrand();
        }

        public async Task<ProductType> GetProductTypeAsync(int id)
        {
            ProductTypeDto productTypeDto = await _context
                .ProductTypes
                .FindAsync(id);

            return productTypeDto?.ToProductType();
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
           return await _context
                .Products
                .Include(p => p.ProductType)
                .Include(p => p.ProductBrand)
                .Select(p => p.ToProduct())
                .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await _context
                 .ProductBrands
                 .Select(b => b.ToProductBrand())
                 .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await _context
                 .ProductTypes
                 .Select(t => t.ToProductType())
                 .ToListAsync();
        }
    }
}
