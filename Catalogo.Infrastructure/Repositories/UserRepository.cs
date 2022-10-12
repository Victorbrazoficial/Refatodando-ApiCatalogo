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

        public async Task Cadastrar(User novoUsuario)
        {
            await _catalogoDbContext.AddAsync(novoUsuario);
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _catalogoDbContext.Users.ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _catalogoDbContext.SaveChangesAsync();
        }
    }
}
