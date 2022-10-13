using Catalogo.Core.Repositories;
using MediatR;

namespace Catalogo.Application.Commands.UserCommand
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _userRepository.GetByIdAsync(request.Id);

            usuario.Update(
              request.NomeCompleto,
              request.Email,
              request.Password,
              request.Role,
              request.DataAniversario
                );

            await _userRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
