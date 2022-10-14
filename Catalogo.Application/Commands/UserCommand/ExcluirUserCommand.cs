using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.Application.Commands.UserCommand
{
    public class ExcluirUserCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
