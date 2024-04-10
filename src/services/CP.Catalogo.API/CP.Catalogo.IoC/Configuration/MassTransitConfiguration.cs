using CP.Catalogo.Domain.Consumers;
using CP.Catalogo.Domain.Events;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Sockets;

namespace CP.Catalogo.IoC.Configuration
{
    public static class MassTransitConfiguration
    {
        public static void AddMassTransit(this IServiceCollection services, IConfiguration configuration)
        {

            var rabbitHost = configuration.GetSection($"RabbitMq:Host").Value;
            var rabbitUser = configuration.GetSection($"RabbitMq:Username").Value;
            var rabbitPassword = configuration.GetSection($"RabbitMq:Password").Value;
            var virtualHost = configuration.GetSection($"RabbitMq:VirtualHost").Value;
            
            
            services.AddMassTransit(x =>
            {
                x.AddConsumer<ReadProdutoItemConsumer>();
                x.SetKebabCaseEndpointNameFormatter();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(new Uri(rabbitHost), virtualHost, h =>
                    {
                        h.Username(rabbitUser);
                        h.Password(rabbitPassword);
                    });

                    cfg.Message<IProdutoItemEvent>(e => e.SetEntityName("catalogo.produto.read-produto-item"));
                    cfg.Publish<IProdutoItemEvent>(x => x.BindQueue("catalogo.produto.read-produto-item", "catalogo.produto.read-produto-item", null));

                    cfg.ReceiveEndpoint("catalogo.produto.read-produto-item", endpoint =>
                    {

                        (int retryCount, int intervalFromMiliSeconds) = GetMessageRetryConfig(configuration);
                        endpoint.UseMessageRetry(r =>
                        {
                            r.Interval(retryCount, TimeSpan.FromMilliseconds(intervalFromMiliSeconds));
                            r.Handle<TimeoutException>();
                            r.Handle<SocketException>(x => x.SocketErrorCode.Equals(SocketError.TimedOut));
                        });
                        endpoint.ConfigureConsumer<ReadProdutoItemConsumer>(context);
                    });

                    cfg.ConfigureEndpoints(context);

                });

            });

         }

        public static (int retryCount, int intervalFromMiliseconds) GetMessageRetryConfig(IConfiguration configuration)
        {
            var retryCount = configuration.GetSection($"MessageRetryConfig").GetValue<int>("RetryCount");
            var intervalFromMiliseconds = configuration.GetSection($"MessageRetryConfig").GetValue<int>("IntervalFromMiliSeconds");

            return (retryCount, intervalFromMiliseconds);
        }

    }
}
