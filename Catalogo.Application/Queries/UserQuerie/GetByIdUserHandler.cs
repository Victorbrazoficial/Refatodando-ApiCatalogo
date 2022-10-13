using Catalogo.Application.ViewModels;
using Catalogo.Core.Repositories;
using MediatR;

namespace Catalogo.Application.Queries.UserQuerie
{
    public class GetByIdUserHandler : IRequestHandler<GetByIdUser, DetalhesUserViewModel>
    {
        private IUserRepository _userRepository;

        public GetByIdUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<DetalhesUserViewModel> Handle(GetByIdUser request, CancellationToken cancellationToken)
        {
            var usuario = await _userRepository.GetByIdAsync(request.Id);

            if (usuario is null)
                return null;

            var detalhesUserViewModel = new DetalhesUserViewModel()
            {
                Id = request.Id,
                NomeCompleto = usuario.NomeCompleto,
                Email = usuario.Email,
                Password = usuario.Password,
                Role = usuario.Role,
                DataAniversario = usuario.DataAniversario,
                DataCadastro = usuario.DataCadastro
            };

            return detalhesUserViewModel;
        }
    }
}
