using Catalogo.Application.InputModels;
using Catalogo.Application.Services.Interfaces;
using Catalogo.Application.ViewModels;
using Catalogo.Core.Entities;
using Catalogo.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Application.Services.Implementations
{
    public class CategoriaService : ICategoriaService
    {
        private readonly CatalogoDbContext _catalogoDbContext;

        public CategoriaService(CatalogoDbContext catalogoDbContext)
        {
            _catalogoDbContext = catalogoDbContext;
        }

        public void Exclui(int id)
        {
            var categoria = _catalogoDbContext.Categorias.SingleOrDefault(x => x.CategoriaId == id);

            _catalogoDbContext.Categorias.Remove(categoria);

            _catalogoDbContext.SaveChanges();
        }

        public List<CategoriaViewModel> GetAll(string query)
        {
            var categorias = _catalogoDbContext.Categorias;
            var categoriasViewModel = categorias
                .Select(x => new CategoriaViewModel() {Id = x.CategoriaId, Nome = x.Nome, ImagemUrl = x.ImagemUrl })
                .OrderBy(x => x.Nome)
                .ToList();

            return categoriasViewModel;
        }

        public DetalhesCategoriaIdViewModel GetById(int id)
        {
            var categoria = _catalogoDbContext.Categorias.SingleOrDefault(x => x.CategoriaId == id);

            if (categoria is null)
                return null;

            var detalhesViewModel = new DetalhesCategoriaIdViewModel() 
            { 
                Nome = categoria.Nome, ImagemUrl = categoria.ImagemUrl, Id = categoria.CategoriaId, Produtos = categoria.Produtos 
            };
                    
            return detalhesViewModel;
        }

        public List<DetalhesCategoriaIdViewModel> GetCategoriaProdutos()
        {
            var categorias = _catalogoDbContext.Categorias;

            var categoriaViewModel = categorias
                .Include(p => p.Produtos)
                .Select(x => new DetalhesCategoriaIdViewModel() { Id = x.CategoriaId, Nome = x.Nome, ImagemUrl = x.ImagemUrl, Produtos = x.Produtos })
                .OrderBy(o => o.Id)
                .ToList();

            return categoriaViewModel;

        }
    }
}
