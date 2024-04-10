using Catalogo.Domain.Handlers;
using Catalogo.Domain.Interfaces.Repositories;
using Catalogo.Infra.Repositories;
using CP.Catalogo.Domain.Handlers;
using CP.Catalogo.IoC.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalogo.IoC.Configuration
{
    public static class InjectorBootStrapper
    {
        public static IServiceCollection RegisterServicesIoC(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<ProdutoHandler, ProdutoHandler>();
            services.AddTransient<ReadProdutoItemHandler, ReadProdutoItemHandler>();

            services.AddMassTransit(configuration);

            return services;
        }

    }
}