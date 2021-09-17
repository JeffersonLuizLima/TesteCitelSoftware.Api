using DevCitel.Business.Intefaces;
using DevCitel.Business.Notificacoes;
using DevCitel.Business.Services;
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

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<ICategoriaService, CategoriaService>();

            return services;
        }
    }
}
