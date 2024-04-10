using Catalogo.Domain.Commands;

namespace Catalogo.Commands
{
    public class ReadProdutoItemCommand : CommandBase
    {
        public ReadProdutoItemCommand() { }

        public ReadProdutoItemCommand(string nome, string descricao, decimal preco, string dataCriacao)
        {
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            DataCriacao = dataCriacao;
        }

        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal? Preco { get; set; }
        public string? DataCriacao { get; set; }

    }
}