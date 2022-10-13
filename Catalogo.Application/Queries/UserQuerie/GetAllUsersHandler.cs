using Catalogo.Application.ViewModels;
using Catalogo.Core.Repositories;
using MediatR;

namespace Catalogo.Application.Queries.UserQuerie
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsers, List<UserViewModel>>
    {
        private IUserRepository _userRepository;

        public GetAllUsersHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserViewModel>> Handle(GetAllUsers request, CancellationToken cancellationToken)
        {
            var usuarios = await _userRepository.GetAllAsync();

            var usuariosViewModel = usuarios
                .Select(x => new UserViewModel()
                {
                    Id = x.Id,
                    NomeCompleto = x.NomeCompleto,
                    Email = x.Email,
                    Role = x.Role,
                    DataAniversario = x.DataAniversario,
                    DataCadastro = x.DataCadastro
                })
                .OrderBy(u => u.NomeCompleto)
                .ToList();

            return usuariosViewModel;
        }
    }
}
