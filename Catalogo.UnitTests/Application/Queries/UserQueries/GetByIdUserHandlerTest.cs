using Catalogo.Application.Queries.UserQuerie;
using Catalogo.Core.Entities;
using Catalogo.Core.Repositories;
using Moq;

namespace Catalogo.UnitTests.Application.Queries.UserQueries
{
    public class GetByIdUserHandlerTest
    {
        [Fact]
        public async Task getByIdUserHandler_Executado_RetornarUmDetalhesUserIdViewModel()
        {
            //Assert
            var usuarios = ListaDeUsuarios();
            var userRepository = new Mock<IUserRepository>();
            var getByIdUser = new GetByIdUser() { Id = 2};
            userRepository.Setup(u => u.GetByIdAsync(getByIdUser.Id).Result).Returns(usuarios[1]);
            var getByIdUserHandler = new GetByIdUserHandler(userRepository.Object);

            //Act
            var usuario = await getByIdUserHandler.Handle(getByIdUser, new CancellationToken());

            //Assert
            Assert.NotNull(usuario);
            Assert.Equal(usuarios[1].Id, usuario.Id);
            Assert.Equal(usuarios[1].NomeCompleto, usuario.NomeCompleto);
            Assert.Equal(usuarios[1].Email, usuario.Email);
            Assert.Equal(usuarios[1].Password, usuario.Password);

            userRepository.Verify(u => u.GetByIdAsync(getByIdUser.Id).Result, Times.Once);
        }

        private List<User> ListaDeUsuarios()
        {
            var usuarios = new List<User>()
            {
                new User()
                {
                    Id = 1,
                    NomeCompleto = "Usuario 1",
                    Email = "usuario1@teste.com",
                    Password = "12345678",
                    DataAniversario = DateTime.Now,
                    DataCadastro = DateTime.Now
                },
                new User()
                {
                    Id = 2,
                    NomeCompleto = "Usuario 2",
                    Email = "usuario2@teste.com",
                    Password = "12345678",
                    DataAniversario = DateTime.Now,
                    DataCadastro = DateTime.Now
                },
                new User()
                {
                    Id = 3,
                    NomeCompleto = "Usuario 3",
                    Email = "usuario3@teste.com",
                    Password = "12345678",
                    DataAniversario = DateTime.Now,
                    DataCadastro = DateTime.Now
                }
            };

            return usuarios;
        }
    }
}
