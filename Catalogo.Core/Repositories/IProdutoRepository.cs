using Catalogo.Core.Entities;

namespace Catalogo.Core.Repositories
{
    public interface IProdutoRepository
    {
        Task<List<Produto>> GetAll(string query);

    }
}
