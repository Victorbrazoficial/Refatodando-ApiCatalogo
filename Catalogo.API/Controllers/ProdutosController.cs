using Catalogo.Application.Commands.ProdutoCommand;
using Catalogo.Application.Queries.ProdutoQuerie;
using Catalogo.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.API.Controllers
{
    [Route("api/produtos")]
    [ApiController]
    [Authorize]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        private readonly IMediator _mediator;
        public ProdutosController(IProdutoService produtoService, IMediator mediator)
        {
            _produtoService = produtoService;
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetProdutos(string query)
        {
            var getAllProdutos = new GetAllProdutos() { Query = query };

            var produtos = await _mediator.Send(getAllProdutos);

            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getByIdDetalhes = new GetByIdDetalhesProduto() { Id = id };

            var produto = await _mediator.Send(getByIdDetalhes);

            if (produto is null)
                return NotFound("Produto não encontrado");

            return Ok(produto);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(CadastrarProdutoCommand novoCadastro)
        {
            await _mediator.Send(novoCadastro);

            return CreatedAtAction(nameof(GetById), new { id = novoCadastro.ProdutoId }, novoCadastro);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateProdutoCommand updateProduto)
        {
            await _mediator.Send(updateProduto);

            if (id != updateProduto.Id)
                return NotFound("Produto não encontrado");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new ExcluirProdutoCommand()
            {
                Id = id
            };

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
