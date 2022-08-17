using Catalogo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.API.Controllers
{
    [Route("api/produtos")]
    public class ProdutosController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetProdutos(string query)
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public ActionResult Cadastrar(ProdutoModel produto)
        {
            return CreatedAtAction(nameof(GetById), new { id = produto.IdProduto }, produto);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, ProdutoUpdate produto)
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
