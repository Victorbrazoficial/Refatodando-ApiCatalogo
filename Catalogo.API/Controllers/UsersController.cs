using Catalogo.Application.Commands.UserCommand;
using Catalogo.Application.Queries.UserQuerie;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.API.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
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

            return CreatedAtAction(nameof(GetByIdUser), new { id = request.Id }, request);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdUser(int id)
        {
            var getByIdUSer = new GetByIdUser() { Id = id };

            var usuario = await _mediator.Send(getByIdUSer);

            if (usuario is null)
                return NotFound("Usuario não encontrado.");

            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateUserCommand request)
        {
            await _mediator.Send(request);

            if (request.Id != id)
                return NotFound($"Usuario não encontrado");

            return NoContent();
        }
    }
}
