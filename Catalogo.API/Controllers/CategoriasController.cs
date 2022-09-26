using Catalogo.Application.Commands.CategoriaCommand;
using Catalogo.Application.InputModels;
using Catalogo.Application.Queries.CategoriaQuerie;
using Catalogo.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.API.Controllers
{
    [Route("api/categorias")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;
        private readonly IMediator _mediator;

        public CategoriasController(ICategoriaService categoriaService, IMediator mediator)
        {
            _categoriaService = categoriaService;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategorias(string query)
        {
            var getAllCategoriasQuery = new GetAllCategorias() { Query = query };

            var categoria = await _mediator.Send(getAllCategoriasQuery);
            return Ok(categoria);
        }

        [HttpGet("produtos")]
        public async Task<IActionResult> GetCategoriasProdutos()
        {
            var query = new GetAllCategoriasProdutos();

            var categoriasProdutods = await _mediator.Send(query);
            return Ok(categoriasProdutods);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getByIdDetalhes = new GetByIdDetalhesCategoria() { Id = id };

            var categoria = await _mediator.Send(getByIdDetalhes);
            
            if (categoria is null)
               return NotFound("Categoria não encontrada");
            
            return Ok(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(CadastrarCategoriaCommand cadastroCategoria)
        {
            var cadastraCategoria = await _mediator.Send(cadastroCategoria);

            return CreatedAtAction(nameof(GetById), new { id = cadastroCategoria.CategoriaId }, cadastroCategoria);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCategoriaCommand update)
        {
            await _mediator.Send(update);

            if (id != update.Id)
                return NotFound("Categoria não encontrada");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new ExcluirCategoriaCommand() 
            {
                Id = id 
            };
            
           await _mediator.Send(command);
            
            return NoContent();
        }
    }
}
