using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Skinet.Core
{
    public interface IProductStorage
    {
        Task<Product> GetProductAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsAsync();

        Task<ProductType> GetProductTypeAsync(int id);
        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();

        Task<ProductBrand> GetProductBrandAsync(int id);
        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
    }
}
