using Catalogo.Application.InputModels;
using Catalogo.Application.Services.Interfaces;
using Catalogo.Application.ViewModels;
using Catalogo.Core.Entities;
using Catalogo.Infrastructure.Persistence;

namespace Catalogo.Application.Services.Implementations
{
    public class CategoriaService : ICategoriaService
    {
        private readonly CatalogoDbContext _catalogoDbContext;

        public CategoriaService(CatalogoDbContext catalogoDbContext)
        {
            _catalogoDbContext = catalogoDbContext;
        }

        public void Atualiza(AtulizaCategoriaInputModel inputModel)
        {        
            var categoria = _catalogoDbContext.Categorias.SingleOrDefault(x => x.CategoriaId == inputModel.Id);

            categoria.Update(inputModel.Nome, inputModel.ImagemUrl);

            _catalogoDbContext.SaveChanges();
        }

        public int Cadastra(NovaCategoriaInputModel inputModel)
        {
            var categoria = new Categoria() { CategoriaId = inputModel.CategoriaId, Nome = inputModel.Nome, ImagemUrl = inputModel.ImagemUrl };

            _catalogoDbContext.Categorias.Add(categoria);

            _catalogoDbContext.SaveChanges();

            return categoria.CategoriaId;
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
                .Select(x => new CategoriaViewModel() {Nome = x.Nome, ImagemUrl = x.ImagemUrl })
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
    }
}
