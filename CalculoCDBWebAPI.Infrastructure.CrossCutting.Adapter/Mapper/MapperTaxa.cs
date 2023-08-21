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
        List<TaxaDTO> taxaDTOs = new List<TaxaDTO>();

        public IEnumerable<TaxaDTO> MapperList(IEnumerable<Taxa> taxas)
        {
            foreach (var item in taxas)
            {
                TaxaDTO taxaDto = new TaxaDTO
                {
                    Id = item.Id,
                    Descricao = item.Descricao,
                    ValorPercentual = item.ValorPercentual
                };

                taxaDTOs.Add(taxaDto);
            }

            return taxaDTOs;
        }

        public TaxaDTO MapperToDTO(Taxa taxa)
        {
            TaxaDTO taxaDTO = new TaxaDTO
            {
                Id = taxa.Id,
                Descricao = taxa.Descricao,
                ValorPercentual = taxa.ValorPercentual
            };

            return taxaDTO;
        }

        public Taxa MapperToEntity(TaxaDTO taxaDTO)
        {
            Taxa taxa = new Taxa
            {
                Id = taxaDTO.Id,
                Descricao = taxaDTO.Descricao,
                ValorPercentual = taxaDTO.ValorPercentual
            };

            return taxa;
        }
    }
}
