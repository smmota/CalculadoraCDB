using System.Net.Http.Headers;

namespace CalculoCDBWebAPI.Application.DTO.DTO
{
    public class CalculoDTO
    {
        public Decimal ValorAplicado { get; set; }
        public int QuantidadeMeses { get; set; }
        public Decimal ValorBruto { get; set; }
        public Decimal ValorLiquido { get; set; }

        public CalculoDTO() { }

        public CalculoDTO(decimal? valorAplicado, int? quantidadeMeses, double taxaCDI, double taxaTBDecimal)
        {
            CalculoValorBruto(valorAplicado, quantidadeMeses, taxaCDI, taxaTBDecimal);
            CalculoImpostoRenda(this);
        }

        internal CalculoDTO CalculoValorBruto(decimal? valorAplicado, int? quantidadeMeses, double taxaCDI, double taxaTB)
        {
            try
            {
                ValorAplicado = valorAplicado ?? 0;
                QuantidadeMeses = quantidadeMeses ?? 0;

                taxaTB = 106;

                decimal valorFinal = 0;
                decimal valorInicial = ValorAplicado;

                var taxaTBMes = Math.Round(taxaTB / 100, 2);
                var taxaCDIMes = Math.Round(taxaCDI / 100, 2);
                var taxas = Convert.ToDecimal(Math.Round((taxaCDIMes * taxaTBMes), 2));
                var percentualTaxa = Math.Round((1 + taxas) / 100, 4);

                for (int i = 0; i < quantidadeMeses; i++)
                {
                    var rendimento = Math.Round(valorInicial * percentualTaxa, 2);
                    valorFinal = valorInicial + rendimento;
                    valorInicial = valorFinal;
                }

                ValorBruto = valorFinal;
                return new CalculoDTO();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal CalculoDTO CalculoImpostoRenda(CalculoDTO calculoDTO)
        {
            try
            {
                decimal taxaImpostoRenda = 0;

                if (calculoDTO.QuantidadeMeses > 1 && calculoDTO.QuantidadeMeses <= 6)
                    taxaImpostoRenda = Math.Round(Convert.ToDecimal(22.5), 2);
                else if(calculoDTO.QuantidadeMeses > 6 && calculoDTO.QuantidadeMeses <= 12)
                    taxaImpostoRenda = Math.Round(Convert.ToDecimal(20.0), 2);
                else if (calculoDTO.QuantidadeMeses > 12 && calculoDTO.QuantidadeMeses <= 24)
                    taxaImpostoRenda = Math.Round(Convert.ToDecimal(17.5), 2);
                else if (calculoDTO.QuantidadeMeses > 24)
                    taxaImpostoRenda = Math.Round(Convert.ToDecimal(15.0), 2);

                var lucro = (Math.Round(calculoDTO.ValorBruto, 2) - Math.Round(calculoDTO.ValorAplicado, 2));

                var valorImpostoRenda = Math.Round(Math.Round(lucro, 2) * Math.Round((taxaImpostoRenda/100), 2), 2);
                calculoDTO.ValorLiquido = Math.Round((calculoDTO.ValorBruto - valorImpostoRenda), 2);

                return calculoDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
