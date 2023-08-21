using CalculoCDBWebAPI.Domain.Core.Interfaces.Repositorys;
using CalculoCDBWebAPI.Domain.Core.Interfaces.Services;
using CalculoCDBWebAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculoCDBWebAPI.Domain.Services.Services
{
    public class ServiceTaxa : ServiceBase<Taxa>, IServiceTaxa
    {
        private readonly IRepositoryTaxa _repository;

        public ServiceTaxa(IRepositoryTaxa repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
