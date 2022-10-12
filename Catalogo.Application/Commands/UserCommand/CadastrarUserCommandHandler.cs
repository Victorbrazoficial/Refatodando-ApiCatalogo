using Catalogo.Core.Entities;
using Catalogo.Core.Repositories;
using MediatR;

namespace Catalogo.Application.Commands.UserCommand
{
    public class CadastrarUserCommandHandler : IRequestHandler<CadastrarUserCommand, int>
    {
        private IUserRepository _userRepository;

        public CadastrarUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> Handle(CadastrarUserCommand request, CancellationToken cancellationToken)
        {
            var novoUsuario = new User()
            {
                Id = request.Id,
                NomeCompleto = request.NomeCompleto,
                Email = request.Email,
                Password = request.Password,
                DataAniversario = request.DataAniversario,
                Role = request.Role
            };

            await _userRepository.Cadastrar(novoUsuario);
            await _userRepository.SaveChangesAsync();

            return novoUsuario.Id;
        }
    }
}
