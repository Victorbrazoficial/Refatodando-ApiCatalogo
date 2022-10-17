using Catalogo.Core.Entities;

namespace Catalogo.Core.Repositories
{
    public interface IUserRepository
    {
        Task CadastrarAsync(User novoUsuario);
        Task<List<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash);
        Task Excluir(int id);
        Task SaveChangesAsync();
    }
}
