using Catalogo.Application.InputModels;
using Catalogo.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.API.Controllers
{
    [Route("api/categorias")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriasController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public ActionResult GetCategorias(string query)
        {
            var categoria = _categoriaService.GetAll(query);
            return Ok(categoria);
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
        public ActionResult Cadastrar(NovaCategoriaInputModel novaCategoria)
        {
            var cadastraCategoria = _categoriaService.Cadastra(novaCategoria);

            return CreatedAtAction(nameof(GetById), new { id = novaCategoria.CategoriaId }, novaCategoria);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, AtulizaCategoriaInputModel inputModel)
        {
            _categoriaService.Atualiza(inputModel);

            if (id != inputModel.Id)
                return NotFound("Categoria não encontrada");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _categoriaService.Exclui(id);
            
            return NoContent();
        }
    }
}
