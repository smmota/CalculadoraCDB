using CalculoCDBWebAPI.Application.DTO.DTO;
using CalculoCDBWebAPI.Domain.Models;
using CalculoCDBWebAPI.Infrastructure.CrossCutting.Adapter.Interfaces;

namespace CalculoCDBWebAPI.Infrastructure.CrossCutting.Adapter.Mapper
{
    public class MapperCalculo : IMapperCalculo
    {
        List<CalculoDTO> calculoDTOs = new List<CalculoDTO>();

        public IEnumerable<CalculoDTO> MapperList(IEnumerable<Calculo> calculos)
        {
            foreach (var item in calculos)
            {
                CalculoDTO calculoDto = new CalculoDTO
                {
                    ValorAplicado = item.ValorAplicado,
                    QuantidadeMeses = item.QuantidadeMeses,
                    ValorBruto = item.ValorBruto,
                    ValorLiquido = item.ValorLiquido
                };

                calculoDTOs.Add(calculoDto);
            }

            return calculoDTOs;
        }

        public CalculoDTO MapperToDTO(Calculo calculo)
        {
            CalculoDTO calculoDTO = new CalculoDTO
            {
                ValorAplicado = calculo.ValorAplicado,
                ValorBruto = calculo.ValorBruto,
                QuantidadeMeses = calculo.QuantidadeMeses,
                ValorLiquido = calculo.ValorLiquido
            };

            return calculoDTO;
        }

        public Calculo MapperToEntity(CalculoDTO calculoDTO)
        {
            Calculo calculo = new Calculo
            {
                ValorAplicado = calculoDTO.ValorAplicado,
                ValorBruto = calculoDTO.ValorBruto,
                QuantidadeMeses = calculoDTO.QuantidadeMeses,
                ValorLiquido = calculoDTO.ValorLiquido
            };

            return calculo;
        }
    }
}
