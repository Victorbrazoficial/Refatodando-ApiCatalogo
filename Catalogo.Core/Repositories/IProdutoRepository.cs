using Catalogo.Core.Entities;

namespace Catalogo.Core.Repositories
{
    public interface IProdutoRepository
    {
        Task<List<Produto>> GetAllAsync(string query);
        Task<Produto> GetByIdDetalhesAsync(int id);

    }
}
