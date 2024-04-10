using Catalogo.Commands;
using Catalogo.Commands.Contracts;
using Catalogo.Domain.Interfaces.Repositories;
using Catalogo.Entities;
using Catalogo.Handlers.Contracts;
using Flunt.Notifications;

namespace CP.Catalogo.Domain.Handlers
{
    public class ReadProdutoItemHandler : 
        Notifiable<Notification>,
        IHandler<ReadProdutoItemCommand>
    {

        private readonly IProdutoRepository _produtoRepository;

        public ReadProdutoItemHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public ICommandResult Handler(ReadProdutoItemCommand command)
        {

            if (!command.IsValid)
                return new GenericCommandResult(false, "Ops, os dados informados não estão corretos", command.Notifications);

             var produtoItem = new ProdutoItem(command.Nome, command.Descricao, command.Preco.Value) ;

            _produtoRepository.Create(produtoItem);

            return new GenericCommandResult(true, "Processamento OK", true);
        }
    }
}
