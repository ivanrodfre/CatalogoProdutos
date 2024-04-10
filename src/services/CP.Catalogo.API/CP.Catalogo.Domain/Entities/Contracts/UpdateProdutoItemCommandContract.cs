using Flunt.Validations;
using Catalogo.Commands;

namespace Catalogo.Entities.Contracts
{
    public class CreateProdutoItemCommandContract : Contract<CreateProdutoCommand>
    {
        public CreateProdutoItemCommandContract(CreateProdutoCommand createTodoCommand)
        {
            Requires()
                .IsNotNullOrEmpty(createTodoCommand.Nome, "Nome", "Nome do produto não pode ser vazio!")
                .IsNotNullOrEmpty(createTodoCommand.Descricao, "Nome", "Descrição do produto não pode ser vazia!");
        }
    }
}
