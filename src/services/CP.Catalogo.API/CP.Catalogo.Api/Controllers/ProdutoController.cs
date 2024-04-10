using Catalogo.Commands;
using Catalogo.Domain.Handlers;
using Catalogo.Domain.Interfaces.Repositories;
using Catalogo.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.Api.Controllers
{
    [ApiController]
    [Route("v1/catalogo")]
    public class ProdutoController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public async Task<IEnumerable<ProdutoItem>> GetAll([FromServices]IProdutoRepository repository)
        {
            return await repository.GetAll();
        }

        [Route("{id:Guid}")]
        [HttpGet]
        public async Task<ProdutoItem>  GetById(Guid id, [FromServices] IProdutoRepository repository)
        {
            return await repository.GetById(id);
        }


        [Route("")]
        [HttpPost]
        public async Task<GenericCommandResult> Create([FromBody] CreateProdutoCommand command, [FromServices] ProdutoHandler handler)
        {
            return (GenericCommandResult)await handler.Handler(command);
        }

        [Route("")]
        [HttpPut]
        public GenericCommandResult Update([FromBody] UpdateProdutoCommand command, [FromServices] ProdutoHandler handler)
        {
            return (GenericCommandResult)handler.Handler(command);
        }

        [Route("{id:Guid}")]
        [HttpDelete]
        public void DeleteById(Guid id, [FromServices] IProdutoRepository repository)
        {
            repository.Excluir(id);
        }

    }
}
