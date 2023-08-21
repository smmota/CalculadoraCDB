using CalculoCDBWebAPI.Application.DTO.DTO;
using CalculoCDBWebAPI.Application.Interfaces;
using CalculoCDBWebAPI.Application.Service;
using CalculoCDBWebAPI.Domain.Core.Interfaces.Services;
using CalculoCDBWebAPI.Infrastructure.CrossCutting.Adapter.Interfaces;
using Moq;
using System.Linq;

namespace CalculoCDBWebAPI.Application.Tests
{
    public class CalculadoraTests
    {
        private readonly ApplicationServiceTaxa _serviceTaxa;

        public CalculadoraTests()
        {
            _serviceTaxa = new ApplicationServiceTaxa(new Mock<IServiceTaxa>().Object, new Mock<IMapperTaxa>().Object);
        }

        [Fact]
        public void ValidaValorBruto()
        {
            decimal? valorAplicado = Convert.ToDecimal(100.00);
            int? prazo = 8;
            double txCDI = 0.9;
            double txTB = 108;

            CalculoDto calculo = new CalculoDto(valorAplicado, prazo, txCDI, txTB);

            Assert.Equal(Convert.ToDecimal(108.36), calculo.ValorBruto);
        }

        [Fact]
        public void ValidaValorLiquido()
        {
            decimal? valorAplicado = Convert.ToDecimal(100.00);
            int? prazo = 8;
            double txCDI = 0.9;
            double txTB = 108;

            CalculoDto calculo = new CalculoDto(valorAplicado, prazo, txCDI, txTB);

            Assert.Equal(Convert.ToDecimal(106.69), calculo.ValorLiquido);
        }

        [Fact]
        public void ObterTaxas()
        {
            Assert.Empty(_serviceTaxa.GetAll().Result);
        }
    }
}