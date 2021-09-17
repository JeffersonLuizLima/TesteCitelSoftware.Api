using DevCitel.Business.Intefaces;
using DevCitel.Data.Context;
using DevCitel.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace DevCitel.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            return services;
        }
    }
}
