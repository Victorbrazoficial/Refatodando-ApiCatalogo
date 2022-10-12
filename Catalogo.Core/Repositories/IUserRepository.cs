using Catalogo.Core.Entities;

namespace Catalogo.Core.Repositories
{
    public interface IUserRepository
    {
        Task Cadastrar(User novoUsuario);
        Task<List<User>> GetAllAsync();
        Task SaveChangesAsync();
    }
}
