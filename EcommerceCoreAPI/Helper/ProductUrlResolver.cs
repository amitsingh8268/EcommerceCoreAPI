using AutoMapper;
using Core.Entities;
using EcommerceCoreAPI.Dtos;

namespace EcommerceCoreAPI.Helper
{
    public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDTO, string>
    {
        public ProductUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IConfiguration _configuration;

        public string Resolve(Product source, ProductToReturnDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _configuration["ApiUrl"] + source.PictureUrl;
            }
            return null;
            
        }
    }
}
