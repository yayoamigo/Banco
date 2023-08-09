using Banco.WebApi.Core.Helpers;
using Banco.WebApi.Core.Services;
using Banco.WebApi.Entity;
using Microsoft.Extensions.Logging;
using Moq;
using RepositoryContracts;
using ServiceContracts.DTO;
using System;
using System.Threading.Tasks;
using Xunit;

namespace BancoTest.unitTest
{

    public class ClienteAddServiceTests
    {
        private readonly Mock<IClientesRepository> _clientesRepositoryMock;
        private readonly Mock<ILogger<ClienteAddService>> _loggerMock;

        public ClienteAddServiceTests()
        {
            _clientesRepositoryMock = new Mock<IClientesRepository>();
            _loggerMock = new Mock<ILogger<ClienteAddService>>();
        }

        [Fact]
        public async Task AddCliente_NullRequest_ThrowsArgumentNullException()
        {
            var service = new ClienteAddService(_clientesRepositoryMock.Object, _loggerMock.Object);
            await Assert.ThrowsAsync<ArgumentNullException>(() => service.AddCliente(null));
        }

        [Fact]
        public async Task AddCliente_ZeroIdentificacion_ThrowsArgumentException()
        {
            var request = new ClienteAddRequest
            {
                Identificacion = 0,
                Contrasena = "password",
                ClienteId = 1
            };
            var service = new ClienteAddService(_clientesRepositoryMock.Object, _loggerMock.Object);
            await Assert.ThrowsAsync<ArgumentException>(() => service.AddCliente(request));
        }

        [Fact]
        public async Task AddCliente_NullContrasena_ThrowsArgumentException()
        {
            var request = new ClienteAddRequest
            {
                Identificacion = 1,
                Contrasena = null,
                ClienteId = 1
            };
            var service = new ClienteAddService(_clientesRepositoryMock.Object, _loggerMock.Object);
            await Assert.ThrowsAsync<ArgumentException>(() => service.AddCliente(request));
        }

        [Fact]
        public async Task AddCliente_ClienteIdExists_ThrowsArgumentException()
        {
            var request = new ClienteAddRequest
            {
                Identificacion = 1,
                Contrasena = "password",
                ClienteId = 1
            };
            _clientesRepositoryMock.Setup(r => r.GetClienteByClienteID(request.ClienteId)).ReturnsAsync(new Cliente());

            var service = new ClienteAddService(_clientesRepositoryMock.Object, _loggerMock.Object);
            await Assert.ThrowsAsync<ArgumentException>(() => service.AddCliente(request));
        }

        [Fact]
        public async Task AddCliente_ValidRequest_ReturnsClienteResponse()
        {
            var request = new ClienteAddRequest
            {
                Identificacion = 1,
                Contrasena = "password",
                ClienteId = 1
            };
            _clientesRepositoryMock.Setup(r => r.GetClienteByClienteID(request.ClienteId)).ReturnsAsync((Cliente)null);

            var service = new ClienteAddService(_clientesRepositoryMock.Object, _loggerMock.Object);
            var response = await service.AddCliente(request);

            Assert.NotNull(response);
            Assert.Equal(request.Identificacion, response.Identificacion);
            Assert.Equal(request.ClienteId, response.ClienteId);
        }
    }
}
