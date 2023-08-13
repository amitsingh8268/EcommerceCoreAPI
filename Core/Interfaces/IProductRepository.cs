using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsAsync(int productId);

        Task<IReadOnlyList<Product>> GetProductsAsAsync();

        Task<IReadOnlyList<ProductBrand>> GetProductBrandAsAsync();

        Task<IReadOnlyList<ProductType>> GetProductTypeAsAsync();
    }
}
