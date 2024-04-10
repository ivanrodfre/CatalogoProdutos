namespace Catalogo.Entities
{
    public class ProdutoItem : Entity
    {
        public ProdutoItem(string? nome, string? descricao, decimal preco)
        {
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            DataCriacao = DateTime.Now;
        }

        public string? Nome { get; private set; }
        public string? Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public DateTime DataCriacao { get; private set; }


        public void UpdateProduto(string nome, string descricao, decimal preco)
        {
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
        }

    }
}
