using Catalogo.Application.ViewModels;
using Catalogo.Core.Repositories;
using MediatR;

namespace Catalogo.Application.Queries.ProdutoQuerie
{
    public class GetByIdDetalhesProdutoHandler : IRequestHandler<GetByIdDetalhesProduto, DetalhesProdutoIdViewModel>
    {
        private IProdutoRepository _produtoRepository;

        public GetByIdDetalhesProdutoHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<DetalhesProdutoIdViewModel> Handle(GetByIdDetalhesProduto request, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.GetByIdDetalhesAsync(request.Id);

            if (produto is null)
                return null;

            var detalhesProdutoId = new DetalhesProdutoIdViewModel()
            {
                ProdutoId = produto.ProdutoId,
                Nome = produto.Nome,
                Preco = produto.Preco,
                Descricao = produto.Descricao,
                ImagemUrl = produto.ImagemUrl,
                Estoque = produto.Estoque,
                DataCadastro = produto.DataCadastro,
                CategoriaId = produto.CategoriaId
            };

            return detalhesProdutoId;
        }
    }
}
