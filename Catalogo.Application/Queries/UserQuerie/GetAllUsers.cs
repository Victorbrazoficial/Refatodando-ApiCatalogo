using Catalogo.Application.ViewModels;
using MediatR;

namespace Catalogo.Application.Queries.UserQuerie
{
    public class GetAllUsers : IRequest<List<UserViewModel>>
    {
    }
}
