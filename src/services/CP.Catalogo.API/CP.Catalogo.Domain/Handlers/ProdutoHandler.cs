using Catalogo.Commands;
using Catalogo.Commands.Contracts;
using Catalogo.Domain.Interfaces.Repositories;
using Catalogo.Handlers.Contracts;
using CP.Catalogo.Domain.Events;
using Flunt.Notifications;
using MassTransit;

namespace Catalogo.Domain.Handlers
{
    public class ProdutoHandler:
        Notifiable<Notification>,
        IHandlerAsync<CreateProdutoCommand>,
        IHandler<UpdateProdutoCommand>
    {


        private IPublishEndpoint _publishEndpoint;
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoHandler(IPublishEndpoint publishEndpoint, IProdutoRepository produtoRepository)
        {
            _publishEndpoint = publishEndpoint;
            _produtoRepository = produtoRepository;
        }

        public async Task<ICommandResult> Handler(CreateProdutoCommand command)
        {

            command.Validate();

            if (!command.IsValid)
                return new GenericCommandResult(false, "Ops, parece que há algo de errado no produto!", command.Notifications);
            
            return new GenericCommandResult(true, "Produto salvo com sucesso!", await SendQueue(command));
        }

        public ICommandResult Handler(UpdateProdutoCommand command)
        {

            command.Validate();

            if (!command.IsValid)
                return new GenericCommandResult(false, "Ops, parece que seu produto está errado!", command.Notifications);

            var produtoItem = _produtoRepository.GetById(command.Id).Result;

            produtoItem.UpdateProduto(command.Nome, command.Descricao, command.Preco);

            _produtoRepository.Upgrade(produtoItem);

            return new GenericCommandResult(true, "Produto atualizado", produtoItem);
        }

        private async Task<CreateProdutoCommand> SendQueue(CreateProdutoCommand command)
        {
            var produtoItemFila = new CreateProdutoCommand(command.Nome, command.Descricao, command.Preco);

            try
            {
                await _publishEndpoint.Publish<IProdutoItemEvent>(new
                {
                    Id = new NewId(),
                    Nome = command.Nome,
                    Descricao = command.Descricao,
                    Preco = command.Preco,
                    DataCriacao = DateTime.Now
                });
            }
            catch (Exception ex)
            {
                throw;
            }

            return produtoItemFila;
        }

    }
}
