using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;

        public ProductController(IGenericRepository<Product> productRepo, IGenericRepository<ProductBrand> productBrandRepo, IGenericRepository<ProductType> productTypeRepo)
        {
            _productRepo = productRepo;
            _productBrandRepo = productBrandRepo;
            _productTypeRepo = productTypeRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts()
        {
            var products = await _productRepo.GetListAsAsync();
            return Ok(products);
        }

        [HttpGet("id")]
        public async  Task<ActionResult<Product>> GetProductById(int id) { 
            var product = await _productRepo.GetByIdAsAsync(id);
            return Ok(product);
        }

        [HttpGet("Brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            var productBrands = await _productBrandRepo.GetListAsAsync();
            return Ok(productBrands);
        }

        [HttpGet("Types")]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProductTypes()
        {
            var productType = await _productTypeRepo.GetListAsAsync();
            return Ok(productType);
        }



    }
}
    