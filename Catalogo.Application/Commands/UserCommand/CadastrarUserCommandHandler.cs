using Catalogo.Core.Entities;
using Catalogo.Core.Repositories;
using Catalogo.Core.Service;
using MediatR;

namespace Catalogo.Application.Commands.UserCommand
{
    public class CadastrarUserCommandHandler : IRequestHandler<CadastrarUserCommand, int>
    {
        private IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public CadastrarUserCommandHandler(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<int> Handle(CadastrarUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var novoUsuario = new User()
            {
                Id = request.Id,
                NomeCompleto = request.NomeCompleto,
                Email = request.Email,
                Password = passwordHash,
                DataAniversario = request.DataAniversario,
                Role = request.Role
            };

            await _userRepository.CadastrarAsync(novoUsuario);
            await _userRepository.SaveChangesAsync();

            return novoUsuario.Id;
        }
    }
}
