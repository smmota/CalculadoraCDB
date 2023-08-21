using CalculoCDBWebAPI.Application.DTO.DTO;
using CalculoCDBWebAPI.Domain.Models;
using CalculoCDBWebAPI.Infrastructure.CrossCutting.Adapter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculoCDBWebAPI.Infrastructure.CrossCutting.Adapter.Mapper
{
    public class MapperTaxa : IMapperTaxa
    {
        private readonly List<TaxaDto> TaxaDtos = new List<TaxaDto>();

        public IEnumerable<TaxaDto> MapperList(IEnumerable<Taxa> taxas)
        {
            foreach (var item in taxas)
            {
                TaxaDto TaxaDto = new TaxaDto
                {
                    Id = item.Id,
                    Descricao = item.Descricao,
                    ValorPercentual = item.ValorPercentual
                };

                TaxaDtos.Add(TaxaDto);
            }

            return TaxaDtos;
        }

        public TaxaDto MapperToDTO(Taxa taxa)
        {
            TaxaDto TaxaDto = new TaxaDto
            {
                Id = taxa.Id,
                Descricao = taxa.Descricao,
                ValorPercentual = taxa.ValorPercentual
            };

            return TaxaDto;
        }

        public Taxa MapperToEntity(TaxaDto TaxaDto)
        {
            Taxa taxa = new Taxa
            {
                Id = TaxaDto.Id,
                Descricao = TaxaDto.Descricao,
                ValorPercentual = TaxaDto.ValorPercentual
            };

            return taxa;
        }
    }
}
