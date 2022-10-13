using Catalogo.Application.ViewModels;
using MediatR;

namespace Catalogo.Application.Queries.UserQuerie
{
    public class GetByIdUser : IRequest<DetalhesUserViewModel>
    {
        public int Id { get; set; }
    }
}
