using System.Net.Http.Headers;

namespace CalculoCDBWebAPI.Application.DTO.DTO
{
    public class CalculoDto
    {
        public Decimal ValorAplicado { get; set; }
        public int QuantidadeMeses { get; set; }
        public Decimal ValorBruto { get; set; }
        public Decimal ValorLiquido { get; set; }

        public CalculoDto() { }

        public CalculoDto(decimal? valorAplicado, int? quantidadeMeses, double taxaCDI, double taxaTBDecimal)
        {
            CalcularInvestimento(valorAplicado, quantidadeMeses, taxaCDI, taxaTBDecimal);
        }

        internal void CalcularInvestimento(decimal? valorAplicado, int? quantidadeMeses, double taxaCDI, double taxaTBDecimal)
        {
            CalculoValorBruto(valorAplicado, quantidadeMeses, taxaCDI, taxaTBDecimal);
            CalculoImpostoRenda(this);
        }

        internal void CalculoValorBruto(decimal? valorAplicado, int? quantidadeMeses, double taxaCDI, double taxaTB)
        {
            if (valorAplicado == null)
                throw new ArgumentException("O valor do investimento deve ser informado.");
            if (quantidadeMeses == null)
                throw new ArgumentException("O prazo do investimento deve ser informado.");
            if (valorAplicado == 0)
                throw new ArgumentException("O valor do investimento deve ser maior que zero.");
            if (quantidadeMeses <= 1)
                throw new ArgumentException("O prazo do investimento deve ser ser maior que um.");
            if (taxaCDI == 0)
                throw new ArgumentException("A taxa CDI deve ser maior que zero.");
            if (taxaTB == 0)
                throw new ArgumentException("A taxa TB deve ser maior que zero.");

            ValorAplicado = valorAplicado ?? 0;
            QuantidadeMeses = quantidadeMeses ?? 0;
            ValorBruto = ValorAplicado;

            var taxaTBMes = taxaTB / 100;
            var taxaCDIMes = taxaCDI / 100;
            var taxas = Convert.ToDecimal(taxaCDIMes * taxaTBMes);
            var percentualTaxa = (1 + taxas) / 100;

            for (int i = 0; i < quantidadeMeses; i++)
            {
                var rendimento = Math.Round(ValorBruto * percentualTaxa, 2);
                ValorBruto += rendimento;
            }
        }

        internal void CalculoImpostoRenda(CalculoDto CalculoDto)
        {
            decimal taxaImpostoRenda = 0;

            if (CalculoDto.QuantidadeMeses > 1 && CalculoDto.QuantidadeMeses <= 6)
                taxaImpostoRenda = Convert.ToDecimal(22.5);
            else if (CalculoDto.QuantidadeMeses > 6 && CalculoDto.QuantidadeMeses <= 12)
                taxaImpostoRenda = Convert.ToDecimal(20.0);
            else if (CalculoDto.QuantidadeMeses > 12 && CalculoDto.QuantidadeMeses <= 24)
                taxaImpostoRenda = Convert.ToDecimal(17.5);
            else if (CalculoDto.QuantidadeMeses > 24)
                taxaImpostoRenda = Convert.ToDecimal(15.0);

            var lucro = CalculoDto.ValorBruto - CalculoDto.ValorAplicado;

            var valorImpostoRenda = lucro * (taxaImpostoRenda / 100);
            CalculoDto.ValorLiquido = Math.Round((CalculoDto.ValorBruto - valorImpostoRenda), 2);
        }
    }
}
