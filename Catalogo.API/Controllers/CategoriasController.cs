using Catalogo.Application.Commands.CategoriaCommand;
using Catalogo.Application.InputModels;
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
        public ActionResult GetCategorias(string query)
        {
            var categoria = _categoriaService.GetAll(query);
            return Ok(categoria);
        }

        [HttpGet("produtos")]
        public ActionResult GetCategoriasProdutos()
        {
            var categoriasProdutods = _categoriaService.GetCategoriaProdutos();
            return Ok(categoriasProdutods);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var categoria = _categoriaService.GetById(id);
            
            if (categoria is null)
               return NotFound("Categoria não encontrada");
            
            return Ok(categoria);
        }

        [HttpPost]
        public async Task<ActionResult> Cadastrar(CadastrarCategoriaCommand cadastroCategoria)
        {
            var cadastraCategoria = await _mediator.Send(cadastroCategoria);

            return CreatedAtAction(nameof(GetById), new { id = cadastroCategoria.CategoriaId }, cadastroCategoria);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateCategoriaCommand update)
        {
            await _mediator.Send(update);

            if (id != update.Id)
                return NotFound("Categoria não encontrada");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
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
