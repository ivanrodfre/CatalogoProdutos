using Catalogo.Domain.Commands;
using Catalogo.Entities.Contracts;

namespace Catalogo.Commands
{
    public class CreateProdutoCommand : CommandBase
    {
        public CreateProdutoCommand() { }

        public CreateProdutoCommand(string? nome, string? descricao, decimal preco)
        {
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
        }

        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal Preco { get; set; }

        public void Validate() => AddNotifications(new CreateProdutoItemCommandContract(this));

    }
}