using Catalogo.Application.Commands.UserCommand;
using Catalogo.Application.Queries.UserQuerie;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.API.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var getAllUser = new GetAllUsers();

            var user = await _mediator.Send(getAllUser);

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(CadastrarUserCommand request)
        {
            var cadastrarUsuario = await _mediator.Send(request);

            return CreatedAtAction(nameof(GetAllUsers), new { id = request.Id }, cadastrarUsuario);
        }
    }
}
