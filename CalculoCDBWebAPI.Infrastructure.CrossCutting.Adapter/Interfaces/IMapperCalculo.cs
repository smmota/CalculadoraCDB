using CalculoCDBWebAPI.Application.DTO.DTO;
using CalculoCDBWebAPI.Domain.Models;

namespace CalculoCDBWebAPI.Infrastructure.CrossCutting.Adapter.Interfaces
{
    public interface IMapperCalculo
    {
        Calculo MapperToEntity(CalculoDto CalculoDto);
        IEnumerable<CalculoDto> MapperList(IEnumerable<Calculo> calculos);
        CalculoDto MapperToDTO(Calculo calculo);
    }
}
