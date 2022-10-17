using Catalogo.Application.ViewModels;
using Catalogo.Core.Repositories;
using Catalogo.Core.Service;
using MediatR;

namespace Catalogo.Application.Commands.LoginUserCommand
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;

        public LoginUserCommandHandler(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }

        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            //utilizar o mesmo algoritimo para criar hash dessa senha
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            //buscar no banco de dado user q tenha meu email e senha em formato hash
            var user = await _userRepository.GetUserByEmailAndPasswordAsync(request.Email, passwordHash);

            // se não exitir erro no login
            if (user is null)
                return null;

            // se existir, gero token usando dados do usuario
            var token = _authService.GenerateJwtToken(user.Email);

            return new LoginUserViewModel()
            {
                Email = user.Email,
                Token = token
            };
        }
    }
}
