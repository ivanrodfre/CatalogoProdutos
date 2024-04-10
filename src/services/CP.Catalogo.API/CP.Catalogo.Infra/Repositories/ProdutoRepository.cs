using Catalogo.Domain.Interfaces.Repositories;
using Catalogo.Entities;
using Catalogo.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Infra.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ApplicationContext _applicationContext;

        public ProdutoRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void Create(ProdutoItem produto)
        {
            _applicationContext.Add(produto);
            _applicationContext.SaveChanges();
        }

        public void Upgrade(ProdutoItem produtoItem)
        {
            _applicationContext.Entry(produtoItem).State = EntityState.Modified;
            _applicationContext.SaveChanges();
        }

        public void Excluir(Guid id)
        {
            var produtopItem = _applicationContext.Produtos
                .FirstOrDefaultAsync(x => x.Id == id).Result;

            _applicationContext.Remove(produtopItem);
            _applicationContext.SaveChanges();
        }

        public async Task<IEnumerable<ProdutoItem>> GetAll()
        {
            return await _applicationContext.Produtos
                .AsNoTracking()
                .OrderByDescending(x => x.DataCriacao)
                .ToListAsync();
        }

        public async Task<ProdutoItem> GetById(Guid id) => await _applicationContext.Produtos
                .FirstOrDefaultAsync(x => x.Id == id);
    }
}
