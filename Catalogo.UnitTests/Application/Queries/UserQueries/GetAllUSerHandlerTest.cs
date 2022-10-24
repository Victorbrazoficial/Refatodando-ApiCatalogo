using Catalogo.Application.Queries.UserQuerie;
using Catalogo.Core.Entities;
using Catalogo.Core.Repositories;
using Moq;

namespace Catalogo.UnitTests.Application.Queries.UserQueries
{
    public class GetAllUSerHandlerTest
    {
        [Fact]
        public async Task ExistemTresUsuarios_Executado_RetornarTresUsuariosViewModel()
        {
            //Arranger
            var users = ListaDeUsuarios();
            var userRepository = new Mock<IUserRepository>();
            var getAllUsers = new GetAllUsers();
            userRepository.Setup(u => u.GetAllAsync().Result).Returns(users);
            var getAllUserHandler = new GetAllUsersHandler(userRepository.Object);

            //Act
            var usuarios = await getAllUserHandler.Handle(getAllUsers, new CancellationToken());

            //Assert
            Assert.NotNull(usuarios);
            Assert.NotEmpty(usuarios);
            
            userRepository.Verify(u => u.GetAllAsync().Result, Times.Once);
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
