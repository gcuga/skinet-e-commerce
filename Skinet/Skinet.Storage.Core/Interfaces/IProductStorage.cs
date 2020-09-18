using System.Collections.Generic;
using System.Threading.Tasks;

using Skinet.Core;
using Skinet.Storage.Core.Specifications;

namespace Skinet.Storage.Core.Interfaces
{
    public interface IProductStorage
    {
        Task<Product> GetProductAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsAsync(ProductSpecParams productParams);
        Task<int> GetProductsCountAsync(ProductSpecParams productParams);

        Task<ProductType> GetProductTypeAsync(int id);
        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();

        Task<ProductBrand> GetProductBrandAsync(int id);
        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
    }
}
