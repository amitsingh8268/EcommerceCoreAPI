using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    internal class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandAsAsync()
        {
            return await _appDbContext.ProductBrand.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsAsync(int productId)
        {
            Product? product = await _appDbContext.Products
                            .Include(p => p.ProductType)
                            .Include(p => p.ProductBrand)
                            .FirstOrDefaultAsync(p => p.Id == productId);
            return product;
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsAsync()
        {
            return await _appDbContext.Products.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypeAsAsync()
        {
            return await _appDbContext.ProductTypes.ToListAsync();
        }
    }
}
