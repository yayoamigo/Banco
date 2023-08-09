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
    public class MovimientoAddServiceTests
    {
        private readonly Mock<IMovimientosRepository> _movimientosRepositoryMock;
        private readonly Mock<ICuentasRepository> _cuentasRepositoryMock;

        public MovimientoAddServiceTests()
        {
            _movimientosRepositoryMock = new Mock<IMovimientosRepository>();
            _cuentasRepositoryMock = new Mock<ICuentasRepository>();
        }

        [Fact]
        public async Task AddMovimiento_NullRequest_ThrowsArgumentNullException()
        {
            var service = new MovimientoAddService(_movimientosRepositoryMock.Object, _cuentasRepositoryMock.Object);
            await Assert.ThrowsAsync<ArgumentNullException>(() => service.AddMovimiento(null));
        }

        [Fact]
        public async Task AddMovimiento_CuentaNotExists_ThrowsArgumentException()
        {
            var request = new MovimientoAddRequest { NumeroCuenta = 123, Valor = 10, TipoMovimiento = "Debito" };
            _cuentasRepositoryMock.Setup(r => r.GetCuentaByNumeroCuenta(request.NumeroCuenta)).ReturnsAsync((Cuenta)null);

            var service = new MovimientoAddService(_movimientosRepositoryMock.Object, _cuentasRepositoryMock.Object);
            await Assert.ThrowsAsync<ArgumentException>(() => service.AddMovimiento(request));
        }

        [Fact]
        public async Task AddMovimiento_ZeroValue_ThrowsArgumentException()
        {
            var request = new MovimientoAddRequest { NumeroCuenta = 123, Valor = 0, TipoMovimiento = "Debito" };
            _cuentasRepositoryMock.Setup(r => r.GetCuentaByNumeroCuenta(request.NumeroCuenta)).ReturnsAsync(new Cuenta());

            var service = new MovimientoAddService(_movimientosRepositoryMock.Object, _cuentasRepositoryMock.Object);
            await Assert.ThrowsAsync<ArgumentException>(() => service.AddMovimiento(request));
        }

        [Fact]
        public async Task AddMovimiento_NoBalanceDebit_ThrowsInvalidOperationException()
        {
            var request = new MovimientoAddRequest { NumeroCuenta = 123, Valor = 10, TipoMovimiento = "Debito" };
            _cuentasRepositoryMock.Setup(r => r.GetCuentaByNumeroCuenta(request.NumeroCuenta)).ReturnsAsync(new Cuenta { SaldoInicial = 0 });

            var service = new MovimientoAddService(_movimientosRepositoryMock.Object, _cuentasRepositoryMock.Object);
            await Assert.ThrowsAsync<InvalidOperationException>(() => service.AddMovimiento(request));
        }

        [Fact]
        public async Task AddMovimiento_DailyLimitExceeded_ThrowsInvalidOperationException()
        {
            var request = new MovimientoAddRequest { NumeroCuenta = 123, Valor = -500, TipoMovimiento = "Debito" };
            _cuentasRepositoryMock.Setup(r => r.GetCuentaByNumeroCuenta(request.NumeroCuenta)).ReturnsAsync(new Cuenta { SaldoInicial = 1000 });
            _movimientosRepositoryMock.Setup(r => r.GetTotalRetiradoHoy(request.NumeroCuenta)).ReturnsAsync(600m);

            var service = new MovimientoAddService(_movimientosRepositoryMock.Object, _cuentasRepositoryMock.Object);
            await Assert.ThrowsAsync<InvalidOperationException>(() => service.AddMovimiento(request));
        }

        [Fact]
        public async Task AddMovimiento_DatabaseFailure_ThrowsInvalidOperationException()
        {
            var request = new MovimientoAddRequest { NumeroCuenta = 123, Valor = 10, TipoMovimiento = "Debito" };
            _cuentasRepositoryMock.Setup(r => r.GetCuentaByNumeroCuenta(request.NumeroCuenta)).ReturnsAsync(new Cuenta { SaldoInicial = 1000 });
            _movimientosRepositoryMock.Setup(r => r.RealizarMovimiento(request.NumeroCuenta, request.Valor, request.TipoMovimiento)).ReturnsAsync(false);

            var service = new MovimientoAddService(_movimientosRepositoryMock.Object, _cuentasRepositoryMock.Object);
            await Assert.ThrowsAsync<InvalidOperationException>(() => service.AddMovimiento(request));
        }

        [Fact]
        public async Task AddMovimiento_Success_ReturnsMovimientoResponse()
        {
            // Arrange
            var request = new MovimientoAddRequest { NumeroCuenta = 123, Valor = 10, TipoMovimiento = "Credito" };
            var fakeCuenta = new Cuenta { SaldoInicial = 1000 };

            var movimientosRepositoryMock = new Mock<IMovimientosRepository>();
            var cuentasRepositoryMock = new Mock<ICuentasRepository>();

            movimientosRepositoryMock.Setup(r => r.RealizarMovimiento(request.NumeroCuenta, request.Valor, request.TipoMovimiento)).ReturnsAsync(true);
            cuentasRepositoryMock.Setup(r => r.GetCuentaByNumeroCuenta(request.NumeroCuenta)).ReturnsAsync(fakeCuenta);

            var service = new MovimientoAddService(movimientosRepositoryMock.Object, cuentasRepositoryMock.Object);

            // Act
            var response = await service.AddMovimiento(request);

            // Assert
            Assert.NotNull(response); // Ensure response is not null
            Assert.Equal(request.NumeroCuenta, response.NumeroCuenta); // Check if the NumeroCuenta matches
            Assert.Equal(request.Valor, response.Valor); // Check if the Valor matches
            Assert.Equal(request.TipoMovimiento, response.TipoMovimiento); // Check if the TipoMovimiento matches

        }


    }
}
