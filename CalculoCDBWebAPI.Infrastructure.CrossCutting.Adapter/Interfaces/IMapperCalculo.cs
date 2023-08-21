using CalculoCDBWebAPI.Application.DTO.DTO;
using CalculoCDBWebAPI.Domain.Models;

namespace CalculoCDBWebAPI.Infrastructure.CrossCutting.Adapter.Interfaces
{
    public interface IMapperCalculo
    {
        Calculo MapperToEntity(CalculoDTO calculoDTO);
        IEnumerable<CalculoDTO> MapperList(IEnumerable<Calculo> calculos);
        CalculoDTO MapperToDTO(Calculo calculo);
    }
}
