using Catalogo.Domain.Commands;
using Catalogo.Entities.Contracts;

namespace Catalogo.Commands
{
    public class UpdateProdutoCommand : CommandBase
    {
        public UpdateProdutoCommand() { }

        public UpdateProdutoCommand(Guid id, string? nome, string? descricao, decimal preco)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
        }

        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal Preco { get; set; }

        public void Validate() => AddNotifications(new UpdateProdutoItemCommandContract(this));

    }
}