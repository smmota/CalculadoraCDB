using CalculoCDBWebAPI.Application.DTO.DTO;
using CalculoCDBWebAPI.Domain.Models;
using CalculoCDBWebAPI.Infrastructure.CrossCutting.Adapter.Interfaces;

namespace CalculoCDBWebAPI.Infrastructure.CrossCutting.Adapter.Mapper
{
    public class MapperCalculo : IMapperCalculo
    {
        private readonly List<CalculoDto> CalculoDtos = new List<CalculoDto>();

        public IEnumerable<CalculoDto> MapperList(IEnumerable<Calculo> calculos)
        {
            foreach (var item in calculos)
            {
                CalculoDto CalculoDto = new CalculoDto
                {
                    ValorAplicado = item.ValorAplicado,
                    QuantidadeMeses = item.QuantidadeMeses,
                    ValorBruto = item.ValorBruto,
                    ValorLiquido = item.ValorLiquido
                };

                CalculoDtos.Add(CalculoDto);
            }

            return CalculoDtos;
        }

        public CalculoDto MapperToDTO(Calculo calculo)
        {
            CalculoDto CalculoDto = new CalculoDto
            {
                ValorAplicado = calculo.ValorAplicado,
                ValorBruto = calculo.ValorBruto,
                QuantidadeMeses = calculo.QuantidadeMeses,
                ValorLiquido = calculo.ValorLiquido
            };

            return CalculoDto;
        }

        public Calculo MapperToEntity(CalculoDto CalculoDto)
        {
            Calculo calculo = new Calculo
            {
                ValorAplicado = CalculoDto.ValorAplicado,
                ValorBruto = CalculoDto.ValorBruto,
                QuantidadeMeses = CalculoDto.QuantidadeMeses,
                ValorLiquido = CalculoDto.ValorLiquido
            };

            return calculo;
        }
    }
}
