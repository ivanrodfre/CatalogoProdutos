using Catalogo.Commands;
using CP.Catalogo.Domain.Events;
using CP.Catalogo.Domain.Handlers;
using MassTransit;

namespace CP.Catalogo.Domain.Consumers
{
    public class ReadProdutoItemConsumer : IConsumer<IProdutoItemEvent>
    {

        readonly ReadProdutoItemHandler _handler;

        public ReadProdutoItemConsumer(ReadProdutoItemHandler readProdutoItemHandler)
        {
            _handler = readProdutoItemHandler;
        }

        public async Task Consume(ConsumeContext<IProdutoItemEvent> context)
        {

            var command = new ReadProdutoItemCommand(
                nome: context.Message.Nome, 
                descricao: context.Message.Descricao,
                preco: context.Message.Preco.Value,
                dataCriacao: context.Message.DataCriacao);


            var TESTE = context.Message.Preco.ToString();

            await Task.Factory.StartNew(() =>
            {
                _handler.Handler(command);
            });

        }
    }
}
