namespace CP.Catalogo.Domain.Events
{
    public interface IProdutoItemEvent
    {
        string? Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal? Preco { get; set; }
        public string? DataCriacao { get; set; }
    }
}
