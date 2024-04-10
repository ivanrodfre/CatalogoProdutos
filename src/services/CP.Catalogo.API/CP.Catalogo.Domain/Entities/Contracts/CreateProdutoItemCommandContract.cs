using Flunt.Validations;
using Catalogo.Commands;

namespace Catalogo.Entities.Contracts
{
    public class UpdateProdutoItemCommandContract : Contract<UpdateProdutoCommand>
    {
        public UpdateProdutoItemCommandContract(UpdateProdutoCommand updateProdutoCommand)
        {
            Requires()
                .IsNotNullOrEmpty(updateProdutoCommand.Nome, "Nome", "Nome do produto não pode ser vazio!")
                .IsNotNullOrEmpty(updateProdutoCommand.Descricao, "Nome", "Descrição do produto não pode ser vazia!");
        }
    }
}
