using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EcommerceCoreAPI.Extension
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection Services, IConfiguration config) {
            
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            Services.AddSwaggerGen();
            Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(config["connectionString:connection"]));
            Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return Services;
        }
    }
}
