using Catalogo.Commands;
using Catalogo.Domain.Handlers;
using CP.Catalogo.Tests.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CP.Catalogo.Tests.HandlerTests
{
    [TestClass]
    public class CreateProdutoHandlerTests
    {
        private readonly CreateProdutoCommand _invalidCommand = new CreateProdutoCommand(nome: null, descricao: "Descrição teste", preco: 100);
        private readonly CreateProdutoCommand _validCommand = new CreateProdutoCommand(nome: "Titulo do produto", descricao: "Descrição teste", preco: 100);

        private readonly ProdutoHandler _handler = new ProdutoHandler(null, new FakeProdutoRepository());
        private GenericCommandResult _result = new GenericCommandResult();


        [TestMethod]
        public async Task Dado_um_comando_invalido_deve_interromper_a_execucao()
        {

            _result = (GenericCommandResult)await _handler.Handler(_invalidCommand);
            Assert.AreEqual(_result.Success, false);
        }

    }
}
