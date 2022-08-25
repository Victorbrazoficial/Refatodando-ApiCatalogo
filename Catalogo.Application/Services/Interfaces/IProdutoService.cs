
using Catalogo.Application.InputModels;
using Catalogo.Application.ViewModels;

namespace Catalogo.Application.Services.Interfaces
{
    public interface IProdutoService
    {
        List<ProdutoViewModel> GetAll(string query);
        DetalhesProdutoIdViewModel GetById(int id);
        int Cadastra(NovoProdutoInputModel inputModel);
        void Atualiza(AtualizaProdutoInputModel inputModel);
        void Exclui(int id);
    }
}