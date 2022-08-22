
using Catalogo.Application.ViewModels;

namespace Catalogo.Application.Services.Interfaces
{
    public interface IProdutoService
    {
        List<ProdutoViewModel> GetAll(string query);
        DetalhesProdutoViewModel GetById(int id);
        int Cadastra(NovoProdutoImputModel novoProduto);
        void Atualiza(AtualizarProdutoViewModel);
        void Exclui(int id);
    }
}