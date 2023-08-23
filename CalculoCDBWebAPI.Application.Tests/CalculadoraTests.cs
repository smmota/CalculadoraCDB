using CalculoCDBWebAPI.Application.DTO.DTO;

namespace CalculoCDBWebAPI.Application.Tests
{
    public class CalculadoraTests
    {
        public CalculadoraTests() { }

        [Fact]
        public void ValorBruto()
        {
            decimal? valorAplicado = Convert.ToDecimal(100.00);
            int? prazo = 8;
            double txCDI = 0.9;
            double txTB = 108;

            CalculoDto calculo = new(valorAplicado, prazo, txCDI, txTB);

            Assert.Equal(Convert.ToDecimal(108.36), calculo.ValorBruto);
        }

        [Fact]
        public void ValorLiquido()
        {
            decimal? valorAplicado = Convert.ToDecimal(100.00);
            int? prazo = 8;
            double txCDI = 0.9;
            double txTB = 108;

            CalculoDto calculo = new(valorAplicado, prazo, txCDI, txTB);

            Assert.Equal(Convert.ToDecimal(106.69), calculo.ValorLiquido);
        }

        [Fact]
        public void ValorBruto_MaiorValorAplicacao()
        {
            decimal? valorAplicado = Convert.ToDecimal(150.00);
            int? prazo = 8;
            double txCDI = 0.9;
            double txTB = 108;

            CalculoDto calculo = new(valorAplicado, prazo, txCDI, txTB);

            Assert.True(calculo.ValorBruto > calculo.ValorAplicado);
        }

        [Fact]
        public void ValorBruto_MaiorValorLiquido()
        {
            decimal? valorAplicado = Convert.ToDecimal(150.00);
            int? prazo = 8;
            double txCDI = 0.9;
            double txTB = 108;

            CalculoDto calculo = new(valorAplicado, prazo, txCDI, txTB);

            Assert.True(calculo.ValorBruto > calculo.ValorLiquido);
        }

        [Fact]
        public void ValorLiquido_MaiorValorAplicacao()
        {
            decimal? valorAplicado = Convert.ToDecimal(150.00);
            int? prazo = 8;
            double txCDI = 0.9;
            double txTB = 108;

            CalculoDto calculo = new(valorAplicado, prazo, txCDI, txTB);

            Assert.True(calculo.ValorLiquido > calculo.ValorAplicado);
        }

        [Fact]
        public void PrazoInvestimento_MaiorQueUmMes()
        {
            decimal? valorAplicado = Convert.ToDecimal(150.00);
            int? prazo = 8;
            double txCDI = 0.9;
            double txTB = 108;

            CalculoDto calculo = new(valorAplicado, prazo, txCDI, txTB);

            Assert.True(calculo.QuantidadeMeses > 1);
        }

        [Fact]
        public void ValorInvestimento_MaiorQueZero()
        {
            decimal? valorAplicado = Convert.ToDecimal(150.00);
            int? prazo = 8;
            double txCDI = 0.9;
            double txTB = 108;

            CalculoDto calculo = new(valorAplicado, prazo, txCDI, txTB);

            Assert.True(calculo.ValorAplicado > 0);
        }

        [Fact]
        public void PrazoInvestimento_Nulo()
        {
            decimal? valorAplicado = Convert.ToDecimal(100.0);
            int? prazo = null;
            double txCDI = 0.9;
            double txTB = 108;

            Assert.Throws<ArgumentException>(() => new CalculoDto(valorAplicado, prazo, txCDI, txTB));
        }

        [Fact]
        public void PrazoInvestimento_MenorQueDois()
        {
            decimal? valorAplicado = Convert.ToDecimal(100.0);
            int? prazo = 1;
            double txCDI = 0.9;
            double txTB = 108;

            Assert.Throws<ArgumentException>(() => new CalculoDto(valorAplicado, prazo, txCDI, txTB));
        }

        [Fact]
        public void ValorAplicacao_Nulo()
        {
            decimal? valorAplicado = null;
            int? prazo = 8;
            double txCDI = 0.9;
            double txTB = 108;

            Assert.Throws<ArgumentException>(() => new CalculoDto(valorAplicado, prazo, txCDI, txTB));
        }

        [Fact]
        public void ValorAplicacao_Zero()
        {
            decimal? valorAplicado = Convert.ToDecimal(0);
            int? prazo = 8;
            double txCDI = 0.9;
            double txTB = 108;

            Assert.Throws<ArgumentException>(() => new CalculoDto(valorAplicado, prazo, txCDI, txTB));
        }

        [Fact]
        public void TaxaCDI_Zero()
        {
            decimal? valorAplicado = Convert.ToDecimal(100.0);
            int? prazo = 8;
            double txCDI = 0;
            double txTB = 108;

            Assert.Throws<ArgumentException>(() => new CalculoDto(valorAplicado, prazo, txCDI, txTB));
        }

        [Fact]
        public void TaxaTB_Zero()
        {
            decimal? valorAplicado = Convert.ToDecimal(100.0);
            int? prazo = 8;
            double txCDI = 0.9;
            double txTB = 0;

            Assert.Throws<ArgumentException>(() => new CalculoDto(valorAplicado, prazo, txCDI, txTB));
        }
    }
}