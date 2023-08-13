using Core.Entities;
using System.Text.Json;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SendAync(AppDbContext dbContext)
        {
            if (!dbContext.ProductBrand.Any())
            {
                var brandData = File.ReadAllText("../Infrastructure/Data/seedData/brands.json");
                var brand= JsonSerializer.Deserialize<List<ProductBrand>>(brandData);
                dbContext.ProductBrand.AddRange(brand); 

            }

            if (!dbContext.ProductTypes.Any())
            {
                var productTypeData = File.ReadAllText("../Infrastructure/Data/seedData/types.json");
                var type = JsonSerializer.Deserialize<List<ProductType>>(productTypeData);
                dbContext.ProductTypes.AddRange(type);
            }

            if (!dbContext.Products.Any())
            {
                var productData = File.ReadAllText("../Infrastructure/Data/seedData/products.json");
                var product = JsonSerializer.Deserialize<List<Product>>(productData);
                dbContext.Products.AddRange(product);

            }

            if (dbContext.ChangeTracker.HasChanges()) await dbContext.SaveChangesAsync();
        }
    }
}
