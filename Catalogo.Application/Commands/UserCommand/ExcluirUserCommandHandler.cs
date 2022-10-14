using Catalogo.Core.Repositories;
using MediatR;

namespace Catalogo.Application.Commands.UserCommand
{
    public class ExcluirUserCommandHandler : IRequestHandler<ExcluirUserCommand, Unit>
    {
        private IUserRepository _userRepository;

        public ExcluirUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(ExcluirUserCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.Excluir(request.Id);

            await _userRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
