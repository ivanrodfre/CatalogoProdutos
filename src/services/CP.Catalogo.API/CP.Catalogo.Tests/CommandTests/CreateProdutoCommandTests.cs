using Catalogo.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CP.Catalogo.Tests.CommandTests
{
    [TestClass]
    public class CreateProdutoCommandTests
    {

        private readonly CreateProdutoCommand _invalidCommand = new CreateProdutoCommand(nome: null, descricao: "Descrição teste", preco: 100);
        private readonly CreateProdutoCommand _validCommand = new CreateProdutoCommand(nome: "Titulo do produto", descricao: "Descrição teste", preco: 100);


        [TestMethod]
        public void Dado_um_prouto_invalido()
        {
            var command = new CreateProdutoCommand(_invalidCommand.Nome, _invalidCommand.Descricao, _invalidCommand.Preco);
            command.Validate();
            Assert.AreEqual(command.IsValid, false);
        }

        [TestMethod]
        public void Dado_um_produto_valido()
        {
            var command = new CreateProdutoCommand(_validCommand.Nome, _validCommand.Descricao, _validCommand.Preco);
            command.Validate();
            Assert.AreEqual(command.IsValid, true);
        }

    }
}
