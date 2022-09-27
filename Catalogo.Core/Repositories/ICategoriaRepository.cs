using Catalogo.Core.Entities;

namespace Catalogo.Core.Repositories
{
    public interface ICategoriaRepository
    {
        Task<List<Categoria>> GetAll(string query);
    }
}
