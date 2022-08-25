using Catalogo.API.Models;
using Catalogo.Application.Services.Implementations;
using Catalogo.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.API.Controllers
{
    [Route("api/produtos")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        public ProdutosController( IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }
        
        [HttpGet]
        public ActionResult GetProdutos(string query)
        {
            var produtos = _produtoService.GetAll(query);

            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var produto = _produtoService.GetById(id);

            if (produto is null)
                return NotFound("Produto não encontrado");

            return Ok(produto);
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
