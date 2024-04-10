using Catalogo.Domain.Interfaces.Repositories;
using Catalogo.Entities;

namespace CP.Catalogo.Tests.Repositories
{
    public class FakeProdutoRepository : IProdutoRepository
    {
        public void Create(ProdutoItem produtoItem)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProdutoItem>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ProdutoItem> GetById(Guid id)
            => new("Produto 2", "Descrição 2", 100);


        public void Upgrade(ProdutoItem produtoItem)
        {
            throw new NotImplementedException();
        }
    }
}
