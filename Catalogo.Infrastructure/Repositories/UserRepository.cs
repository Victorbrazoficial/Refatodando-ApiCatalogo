using Catalogo.Core.Entities;
using Catalogo.Core.Repositories;
using Catalogo.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private CatalogoDbContext _catalogoDbContext;

        public UserRepository(CatalogoDbContext catalogoDbContext)
        {
            _catalogoDbContext = catalogoDbContext;
        }

        public async Task CadastrarAsync(User novoUsuario)
        {
            await _catalogoDbContext.AddAsync(novoUsuario);
        }

        public async Task Excluir(int id)
        {
            var usuario = await _catalogoDbContext.Users.SingleOrDefaultAsync(u => u.Id == id);

            _catalogoDbContext.Remove(usuario);
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _catalogoDbContext.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            
            var usuario = await _catalogoDbContext.Users.SingleOrDefaultAsync(u => u.Id == id);

            if (usuario is null)
                return null;

            return usuario;
        }

        public async Task SaveChangesAsync()
        {
            await _catalogoDbContext.SaveChangesAsync();
        }
    }
}
