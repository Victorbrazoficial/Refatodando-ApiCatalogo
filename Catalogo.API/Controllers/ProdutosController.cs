using Catalogo.Application.Commands.ProdutoCommand;
using Catalogo.Application.InputModels;
using Catalogo.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.API.Controllers
{
    [Route("api/produtos")]
    [ApiController]
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
        public IActionResult GetProdutos(string query)
        {
            var produtos = _produtoService.GetAll(query);

            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var produto = _produtoService.GetById(id);

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
