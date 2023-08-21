using CalculoCDBWebAPI.Application.DTO.DTO;
using CalculoCDBWebAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculoCDBWebAPI.Infrastructure.CrossCutting.Adapter.Interfaces
{
    public interface IMapperTaxa
    {
        Taxa MapperToEntity(TaxaDto TaxaDto);
        IEnumerable<TaxaDto> MapperList(IEnumerable<Taxa> taxas);
        TaxaDto MapperToDTO(Taxa taxa);
    }
}
