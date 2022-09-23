using Catalogo.Application.InputModels;
using Catalogo.Application.ViewModels;

namespace Catalogo.Application.Services.Interfaces
{
    public interface ICategoriaService
    {
        List<CategoriaViewModel> GetAll(string query);
        List<DetalhesCategoriaIdViewModel> GetCategoriaProdutos();
        DetalhesCategoriaIdViewModel GetById(int id);
    }
}
