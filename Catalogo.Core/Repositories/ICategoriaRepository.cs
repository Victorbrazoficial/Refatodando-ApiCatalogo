using Catalogo.Core.Entities;

namespace Catalogo.Core.Repositories
{
    public interface ICategoriaRepository
    {
        Task<List<Categoria>> GetAllAsync(string query);
        Task<Categoria> GetByIdDetalhesAsync(int id);
        Task<List<Categoria>> GetAllCategoriasProdutosAsync();
        Task Cadastrar(Categoria novaCategoria);
    }
}
