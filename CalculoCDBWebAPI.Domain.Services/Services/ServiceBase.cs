using CalculoCDBWebAPI.Domain.Core.Interfaces.Repositorys;
using CalculoCDBWebAPI.Domain.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculoCDBWebAPI.Domain.Services.Services
{
    public abstract class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        protected ServiceBase(IRepositoryBase<TEntity> repository) 
        {
            _repository = repository;
        }

        public virtual async Task<TEntity> Add(TEntity obj)
        {
            return await _repository.Add(obj);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _repository.GetAll();
        }

        public virtual async Task<TEntity> Update(TEntity obj)
        {
            return await _repository.Update(obj);
        }

        public virtual async Task<TEntity> Remove(TEntity obj)
        {
            return await _repository.Remove(obj);
        }

        public virtual async Task<TEntity?> GetById(int id)
        {
            return await _repository.GetById(id);
        }
    }
}
