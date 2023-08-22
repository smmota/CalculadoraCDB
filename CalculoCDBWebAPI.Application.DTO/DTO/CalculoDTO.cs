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
            ValorAplicado = valorAplicado ?? 0;
            QuantidadeMeses = quantidadeMeses ?? 0;
            ValorBruto = ValorAplicado;

            var taxaTBMes = Math.Round(taxaTB / 100, 2);
            var taxaCDIMes = Math.Round(taxaCDI / 100, 2);
            var taxas = Convert.ToDecimal(Math.Round((taxaCDIMes * taxaTBMes), 2));
            var percentualTaxa = Math.Round((1 + taxas) / 100, 4);

            for (int i = 0; i < quantidadeMeses; i++)
            {
                var rendimento = Math.Round(ValorBruto * percentualTaxa, 2);
                ValorBruto = ValorBruto + rendimento;
            }
        }

        internal void CalculoImpostoRenda(CalculoDto CalculoDto)
        {
            decimal taxaImpostoRenda = 0;

            if (CalculoDto.QuantidadeMeses > 1 && CalculoDto.QuantidadeMeses <= 6)
                taxaImpostoRenda = Math.Round(Convert.ToDecimal(22.5), 2);
            else if (CalculoDto.QuantidadeMeses > 6 && CalculoDto.QuantidadeMeses <= 12)
                taxaImpostoRenda = Math.Round(Convert.ToDecimal(20.0), 2);
            else if (CalculoDto.QuantidadeMeses > 12 && CalculoDto.QuantidadeMeses <= 24)
                taxaImpostoRenda = Math.Round(Convert.ToDecimal(17.5), 2);
            else if (CalculoDto.QuantidadeMeses > 24)
                taxaImpostoRenda = Math.Round(Convert.ToDecimal(15.0), 2);

            var lucro = (Math.Round(CalculoDto.ValorBruto, 2) - Math.Round(CalculoDto.ValorAplicado, 2));

            var valorImpostoRenda = Math.Round(Math.Round(lucro, 2) * Math.Round((taxaImpostoRenda / 100), 2), 2);
            CalculoDto.ValorLiquido = Math.Round((CalculoDto.ValorBruto - valorImpostoRenda), 2);
        }
    }
}
