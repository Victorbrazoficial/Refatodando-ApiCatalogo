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
            var categoria = new Categoria { Nome = inputModel.Nome, ImagemUrl = inputModel.ImagemUrl };
        }

        public int Cadastra(NovaCategoriaInputModel inputModel)
        {
            var categoria = new Categoria() { CategoriaId = inputModel.CategoriaId, Nome = inputModel.Nome, ImagemUrl = inputModel.ImagemUrl };

            _catalogoDbContext.Categorias.Add(categoria);

            return categoria.CategoriaId;
        }

        public void Exclui(int id)
        {
            var categoria = _catalogoDbContext.Categorias.SingleOrDefault(x => x.CategoriaId == id);

            _catalogoDbContext.Categorias.Remove(categoria);    
        }

        public List<CategoriaViewModel> GetAll(string query)
        {
            var categorias = _catalogoDbContext.Categorias;
            var categoriasViewModel = categorias
                .Select(x => new CategoriaViewModel(x.Nome))
                .ToList();

            return categoriasViewModel;
        }

        public DetalhesViewModel GetById(int id)
        {
            var categoria = _catalogoDbContext.Categorias.SingleOrDefault(x => x.CategoriaId == id);

            var detalhesViewModel = new DetalhesViewModel() 
            { 
                Nome = categoria.Nome, ImagemUrl = categoria.ImagemUrl 
            };
                    
            return detalhesViewModel;
        }
    }
}
