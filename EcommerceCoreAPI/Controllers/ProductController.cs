using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using EcommerceCoreAPI.Dtos;
using EcommerceCoreAPI.Errors;
using EcommerceCoreAPI.Helper;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceCoreAPI.Controllers
{
    public class ProductController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;

        public ProductController(IGenericRepository<Product> productRepo, IGenericRepository<ProductBrand> productBrandRepo, 
            IGenericRepository<ProductType> productTypeRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _productBrandRepo = productBrandRepo;
            _productTypeRepo = productTypeRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnDTO>>> GetProducts([FromQuery] ProductSpecParams productParams)
        {
            var spec = new ProductWithTypeAndBrandSpecification(productParams);
            var countSpec = new ProductWithFilterForCountSpecification(productParams);
            var totalItems = await _productRepo.CountAsync(countSpec);
            var products = await _productRepo.ListAsync(spec);
            var data = _mapper.Map<IReadOnlyList<ProductToReturnDTO>>(products);
            return Ok(new Pagination<ProductToReturnDTO>(productParams.PageIndex, productParams.PageSize, totalItems, data));
        }

        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse),StatusCodes.Status404NotFound)]
        public async  Task<ActionResult<ProductToReturnDTO>> GetProductById(int id) {
            var spec = new ProductWithTypeAndBrandSpecification(id);
            var product = await _productRepo.GetEntityWithSpec(spec);
            if(product == null) { return NotFound(new ApiResponse(404));}
            return Ok(_mapper.Map<ProductToReturnDTO>(product));
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
    