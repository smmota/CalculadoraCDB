using CalculoCDBWebAPI.Application.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculoCDBWebAPI.Application.Interfaces
{
    public interface IApplicationServiceTaxa
    {
        Task Add(TaxaDto obj);

        Task<TaxaDto> GetById(int id);

        Task<IEnumerable<TaxaDto>> GetAll();

        Task Update(TaxaDto obj);

        Task Remove(TaxaDto obj);

        Task Dispose();
    }
}
