using CalculoCDBWebAPI.Application.DTO.DTO;

namespace CalculoCDBWebAPI.Application.Tests
{
    public class CalculadoraTests
    {
        public CalculadoraTests() { }

        [Fact]
        public void ValorBruto()
        {
            double? valorAplicado = Convert.ToDouble(100.00);
            int? prazo = 8;
            double txCDI = 0.9;
            double txTB = 108;

            CalculoDto calculo = new(valorAplicado, prazo, txCDI, txTB);

            Assert.Equal(Convert.ToDouble(108.05), calculo.ValorBruto);
        }

        [Fact]
        public void ValorLiquido()
        {
            double? valorAplicado = Convert.ToDouble(100.00);
            int? prazo = 8;
            double txCDI = 0.9;
            double txTB = 108;

            CalculoDto calculo = new(valorAplicado, prazo, txCDI, txTB);

            Assert.Equal(Convert.ToDouble(106.44), calculo.ValorLiquido);
        }

        [Fact]
        public void ValorBruto_MaiorValorAplicacao()
        {
            double? valorAplicado = Convert.ToDouble(150.00);
            int? prazo = 8;
            double txCDI = 0.9;
            double txTB = 108;

            CalculoDto calculo = new(valorAplicado, prazo, txCDI, txTB);

            Assert.True(calculo.ValorBruto > calculo.ValorAplicado);
        }

        [Fact]
        public void ValorBruto_MaiorValorLiquido()
        {
            double? valorAplicado = Convert.ToDouble(150.00);
            int? prazo = 8;
            double txCDI = 0.9;
            double txTB = 108;

            CalculoDto calculo = new(valorAplicado, prazo, txCDI, txTB);

            Assert.True(calculo.ValorBruto > calculo.ValorLiquido);
        }

        [Fact]
        public void ValorLiquido_MaiorValorAplicacao()
        {
            double? valorAplicado = Convert.ToDouble(150.00);
            int? prazo = 8;
            double txCDI = 0.9;
            double txTB = 108;

            CalculoDto calculo = new(valorAplicado, prazo, txCDI, txTB);

            Assert.True(calculo.ValorLiquido > calculo.ValorAplicado);
        }

        [Fact]
        public void PrazoInvestimento_MaiorQueUmMes()
        {
            double? valorAplicado = Convert.ToDouble(150.00);
            int? prazo = 8;
            double txCDI = 0.9;
            double txTB = 108;

            CalculoDto calculo = new(valorAplicado, prazo, txCDI, txTB);

            Assert.True(calculo.QuantidadeMeses > 1);
        }

        [Fact]
        public void ValorInvestimento_MaiorQueZero()
        {
            double? valorAplicado = Convert.ToDouble(150.00);
            int? prazo = 8;
            double txCDI = 0.9;
            double txTB = 108;

            CalculoDto calculo = new(valorAplicado, prazo, txCDI, txTB);

            Assert.True(calculo.ValorAplicado > 0);
        }

        [Fact]
        public void PrazoInvestimento_Nulo()
        {
            double? valorAplicado = Convert.ToDouble(100.0);
            int? prazo = null;
            double txCDI = 0.9;
            double txTB = 108;

            Assert.Throws<ArgumentException>(() => new CalculoDto(valorAplicado, prazo, txCDI, txTB));
        }

        [Fact]
        public void PrazoInvestimento_MenorQueDois()
        {
            double? valorAplicado = Convert.ToDouble(100.0);
            int? prazo = 1;
            double txCDI = 0.9;
            double txTB = 108;

            Assert.Throws<ArgumentException>(() => new CalculoDto(valorAplicado, prazo, txCDI, txTB));
        }

        [Fact]
        public void ValorAplicacao_Nulo()
        {
            double? valorAplicado = null;
            int? prazo = 8;
            double txCDI = 0.9;
            double txTB = 108;

            Assert.Throws<ArgumentException>(() => new CalculoDto(valorAplicado, prazo, txCDI, txTB));
        }

        [Fact]
        public void ValorAplicacao_Zero()
        {
            double? valorAplicado = Convert.ToDouble(0);
            int? prazo = 8;
            double txCDI = 0.9;
            double txTB = 108;

            Assert.Throws<ArgumentException>(() => new CalculoDto(valorAplicado, prazo, txCDI, txTB));
        }

        [Fact]
        public void TaxaCDI_Zero()
        {
            double? valorAplicado = Convert.ToDouble(100.0);
            int? prazo = 8;
            double txCDI = 0;
            double txTB = 108;

            Assert.Throws<ArgumentException>(() => new CalculoDto(valorAplicado, prazo, txCDI, txTB));
        }

        [Fact]
        public void TaxaTB_Zero()
        {
            double? valorAplicado = Convert.ToDouble(100.0);
            int? prazo = 8;
            double txCDI = 0.9;
            double txTB = 0;

            Assert.Throws<ArgumentException>(() => new CalculoDto(valorAplicado, prazo, txCDI, txTB));
        }
    }
}