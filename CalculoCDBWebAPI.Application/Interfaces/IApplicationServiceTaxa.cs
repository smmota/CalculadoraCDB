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
        Task Add(TaxaDTO obj);

        Task<TaxaDTO> GetById(int id);

        Task<IEnumerable<TaxaDTO>> GetAll();

        Task Update(TaxaDTO obj);

        Task Remove(TaxaDTO obj);

        Task Dispose();
    }
}
