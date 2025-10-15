using Microsoft.EntityFrameworkCore;
using Prueba.Api.Interfaces;
using Prueba.Api.Services;
using Prueba.Infrastructure.Data;
using Prueba.Infrastructure.Repositories;
using Prueba.Infrastructure.Services;

namespace Prueba.WebApi.Configurations
{
    public static class DependenciesConfig
    {
        public static IServiceCollection AddAplicationDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Repos
            services.AddScoped<IProductoRepository, ProductoRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IBitacoraInventarioRepository, BitacoraInventarioRepository>();

            // Services
            services.AddScoped<IProductoService, ProductoService>();
            services.AddScoped<IPedidoService, PedidoService>();
            
            return services;
        }
    }
}
