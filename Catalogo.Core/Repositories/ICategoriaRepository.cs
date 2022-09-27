using Catalogo.Core.Entities;

namespace Catalogo.Core.Repositories
{
    public interface ICategoriaRepository
    {
        Task<List<Categoria>> GetAllAsync(string query);
        Task<Categoria> GetByIdDetalhesAsync(int id);
    }
}
