using Catalogo.Entities;

namespace Catalogo.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository
    {
        void Create(ProdutoItem produtoItem);
        void Upgrade(ProdutoItem produtoItem);
        void Excluir(Guid id);
        Task<IEnumerable<ProdutoItem>> GetAll();
        Task<ProdutoItem> GetById(Guid id);
    }
}
