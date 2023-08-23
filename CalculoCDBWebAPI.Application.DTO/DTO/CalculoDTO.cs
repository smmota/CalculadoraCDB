using System.Net.Http.Headers;

namespace CalculoCDBWebAPI.Application.DTO.DTO
{
    public class CalculoDto
    {
        public Double ValorAplicado { get; set; }
        public int QuantidadeMeses { get; set; }
        public Double ValorBruto { get; set; }
        public Double ValorLiquido { get; set; }

        public CalculoDto() { }

        public CalculoDto(double? valorAplicado, int? quantidadeMeses, double taxaCDI, double taxaTB)
        {
            CalcularInvestimento(valorAplicado, quantidadeMeses, taxaCDI, taxaTB);
        }

        internal void CalcularInvestimento(double? valorAplicado, int? quantidadeMeses, double taxaCDI, double taxaTB)
        {
            CalculoValorBruto(valorAplicado, quantidadeMeses, taxaCDI, taxaTB);
        }
        
        internal static void Validation(double? valorAplicado, int? quantidadeMeses, double taxaCDI, double taxaTB)
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
        }

        internal void CalculoValorBruto(double? valorAplicado, int? quantidadeMeses, double taxaCDI, double taxaTB)
        {

            Validation(valorAplicado, quantidadeMeses, taxaCDI, taxaTB);

            ValorAplicado = valorAplicado ?? 0;
            QuantidadeMeses = quantidadeMeses ?? 0;
            ValorBruto = ValorAplicado;

            double percentualTaxaTB = taxaTB / 100;
            double percentualTaxaCDI = taxaCDI / 100;

            for (int i = 1; i <= QuantidadeMeses; i++)
            {
                var valorFinal = ValorBruto * (1 + (percentualTaxaCDI * percentualTaxaTB));
                var aliquotaImposto = ObterAliquotaImposto(i);
                var imposto = (valorFinal - ValorAplicado) * aliquotaImposto;
                var valorLiquido = valorFinal - imposto;

                ValorBruto = valorFinal;
                ValorLiquido = valorLiquido;
            }

            ValorBruto = Math.Round(ValorBruto, 2);
            ValorLiquido = Math.Round(ValorLiquido, 2);
        }

        internal static Double ObterAliquotaImposto(int mes)
        {
            double aliquotaImposto = 0;

            if (mes <= 6)
                aliquotaImposto = 22.5;
            else if (mes > 6 && mes <= 12)
                aliquotaImposto = 20.0;
            else if (mes > 12 && mes <= 24)
                aliquotaImposto = 17.5;
            else if (mes > 24)
                aliquotaImposto = 15.0;

            return (aliquotaImposto / 100);
        }
    }
}
