using CalculoCDBWebAPI.Application.DTO.DTO;
using CalculoCDBWebAPI.Application.Interfaces;
using CalculoCDBWebAPI.Domain.Core.Interfaces.Services;
using CalculoCDBWebAPI.Infrastructure.CrossCutting.Adapter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculoCDBWebAPI.Application.Service
{
    public class ApplicationServiceTaxa : IApplicationServiceTaxa
    {
        private readonly IServiceTaxa _service;
        private readonly IMapperTaxa _mapper;

        public ApplicationServiceTaxa(IServiceTaxa service, IMapperTaxa mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task Add(TaxaDto obj)
        {
            var objTaxa = _mapper.MapperToEntity(obj);
            await _service.Add(objTaxa);
        }

        public async Task Dispose()
        {
            await _service.Dispose();
        }

        public async Task<IEnumerable<TaxaDto>> GetAll()
        {
            var objTaxas = await _service.GetAll();
            return _mapper.MapperList(objTaxas);
        }

        public async Task<TaxaDto> GetById(int id)
        {
            var objTaxa = await _service.GetById(id);
            return _mapper.MapperToDTO(objTaxa);
        }

        public async Task Remove(TaxaDto obj)
        {
            var objTaxa = _mapper.MapperToEntity(obj);
            await _service.Remove(objTaxa);
        }

        public async Task Update(TaxaDto obj)
        {
            var objTaxa = _mapper.MapperToEntity(obj);
            await _service.Update(objTaxa);
        }
    }
}
