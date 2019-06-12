using Frota.Application;
using Frota.Application.Enumerators;
using Frota.Application.Interfaces;
using Frota.Application.ViewModels;
using Frota.Domain.Entities;
using Frota.Domain.Interfaces.IServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Frota.Tests
{
    [TestClass]
    public class VeiculoApplicationTest : UnitTestBase
    {
        private readonly Mock<IVeiculoService> _veiculoServiceMock;
        private readonly Mock<IVeiculoApplication> _veiculoApplicationMock;

        public VeiculoApplicationTest()
        {
            _veiculoServiceMock = new Mock<IVeiculoService>();
        }

        [TestMethod]
        public void VeiculoApplication_Adicionar_Return_Be_Sucess()
        {
            var veiculo = new VeiculoModel
            {
                Chassi = "12345678901234567",
                Tipo = TipoVeiculo.Caminhao,
                Cor = "Verde"
            };

            var veiculoApplication = new VeiculoApplication(_veiculoServiceMock.Object);
            veiculoApplication.Adicionar(veiculo);

            _veiculoServiceMock.Verify(r => r.Adicionar(
                It.Is<Veiculo>(v => v.Chassi == veiculo.Chassi)));

        }

        [TestMethod]
        public void VeiculoApplication_Atualizar_Return_Be_Sucess()
        {
            var veiculo = new VeiculoModel
            {
                ID = 1,
                Chassi = "12345678901234567",
                Tipo = TipoVeiculo.Caminhao,
                Cor = "Verde"
            };

            var veiculoApplication = new VeiculoApplication(_veiculoServiceMock.Object);
            veiculoApplication.Atualizar(veiculo);

            _veiculoServiceMock.Verify(r => r.Atualizar(
                It.Is<int>(v => v == veiculo.ID),
                It.Is<string>(v => v == veiculo.Cor)));

        }
    }
}