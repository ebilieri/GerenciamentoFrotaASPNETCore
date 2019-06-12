using Frota.Domain.Entities;
using Frota.Domain.Interfaces.IRepositories;
using Frota.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Frota.Tests
{
    [TestClass]
    public class VeiculoServiceTest : UnitTestBase
    {
        private readonly Mock<IVeiculoRepository> _veiculoRepositoryMock;
        public VeiculoServiceTest()
        {
            _veiculoRepositoryMock = new Mock<IVeiculoRepository>();
        }

        [TestMethod]
        public void VeiculoService_Adicionar_Return_Be_Sucess()
        {
            var veiculo = new Veiculo
            {
                Chassi = "12345678901234567",
                Tipo = 1,
                Cor = "Verde"
            };


            var veiculoService = new VeiculoService(_veiculoRepositoryMock.Object);
            veiculoService.Adicionar(veiculo);

            _veiculoRepositoryMock.Verify(r => r.Adicionar(
                It.Is<Veiculo>(v => v.Chassi == veiculo.Chassi)));

        }

        [TestMethod]
        public void VeiculoService_ObterPorId_Return_Be_Sucess()
        {
            _veiculoRepositoryMock.Setup(x => x.ObterPorId(1)).Returns(new Veiculo
            {
                Id = 1,
                Chassi = "12345678901234567",
                Tipo = 1,
                Cor = "Verde"
            });

            var veiculoService = new VeiculoService(_veiculoRepositoryMock.Object);
            var veiculo = veiculoService.ObterPorId(1);

            _veiculoRepositoryMock.Verify(r => r.ObterPorId(
                It.Is<int>(v => v == veiculo.Id)));
        }

        [TestMethod]
        public void VeiculoService_Atualizar_Return_Be_Sucess()
        {
            _veiculoRepositoryMock.Setup(x => x.ObterPorId(1)).Returns(new Veiculo
            {
                Id = 1,
                Chassi = "12345678901234567",
                Tipo = 1,
                Cor = "Verde"
            });

            var veiculoService = new VeiculoService(_veiculoRepositoryMock.Object);
            var veiculo = veiculoService.ObterPorId(1);
            
            veiculoService.Atualizar(veiculo.Id, veiculo.Cor);

            _veiculoRepositoryMock.Verify(r => r.Atualizar(
                It.Is<Veiculo>(v => v.Id == veiculo.Id)));

        }
    }
}
