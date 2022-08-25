using Catalogo.Application.InputModels;
using Catalogo.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.API.Controllers
{
    [Route("api/produtos")]
    [ApiController]
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
        public ActionResult Cadastrar(NovoProdutoInputModel novoProduto)
        {
            _produtoService.Cadastra(novoProduto);

            return CreatedAtAction(nameof(GetById), new { id = novoProduto.ProdutoId }, novoProduto);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] AtualizaProdutoInputModel inputModel)
        {            
            _produtoService.Atualiza(inputModel);

            if (id != inputModel.Id)
                return NotFound("Produto não encontrado");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}
