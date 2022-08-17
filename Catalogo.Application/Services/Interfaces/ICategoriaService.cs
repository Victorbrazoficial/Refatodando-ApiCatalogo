using Catalogo.Application.InputModels;
using Catalogo.Application.ViewModels;

namespace Catalogo.Application.Services.Interfaces
{
    public interface ICategoriaService
    {
        List<CategoriaViewModel> GetAll(string query);
        DetalhesViewModel GetById(int id);
        int Cadastra(NovaCategoriaInputModel inputModel);
        void Atualiza(AtulizaCategoriaInputModel inputModel);
        void Exclui(int id);
    }
}
