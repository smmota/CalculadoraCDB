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
        Taxa MapperToEntity(TaxaDTO taxaDTO);
        IEnumerable<TaxaDTO> MapperList(IEnumerable<Taxa> taxas);
        TaxaDTO MapperToDTO(Taxa taxa);
    }
}
