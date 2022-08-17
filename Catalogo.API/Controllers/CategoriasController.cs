using Catalogo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.API.Controllers
{
    [Route("api/categorias")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {

        [HttpGet]
        public ActionResult GetCategorias()
        {    
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public ActionResult Cadastrar(CategoriaModel categoria)
        {
            return CreatedAtAction(nameof(GetById), new { id = categoria.IdCategoria }, categoria);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, CategoriaUpdate categoria)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}
