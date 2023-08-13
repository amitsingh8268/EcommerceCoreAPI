using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IGenericRepository<Product> _product;
        private readonly IGenericRepository<ProductBrand> _productBrand;
        private readonly IGenericRepository<ProductType> _productType;

        public ProductController(IGenericRepository<Product> product, IGenericRepository<ProductBrand> productBrand, IGenericRepository<ProductType> productType)
        {
            _product = product;
            _productBrand = productBrand;
            _productType = productType;
        }


        
    }
}
