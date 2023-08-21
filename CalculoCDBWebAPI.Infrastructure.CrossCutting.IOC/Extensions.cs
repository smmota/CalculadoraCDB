using CalculoCDBWebAPI.Application.Interfaces;
using CalculoCDBWebAPI.Application.Service;
using CalculoCDBWebAPI.Domain.Core.Interfaces.Repositorys;
using CalculoCDBWebAPI.Domain.Core.Interfaces.Services;
using CalculoCDBWebAPI.Domain.Services.Services;
using CalculoCDBWebAPI.Infrastructure.CrossCutting.Adapter.Interfaces;
using CalculoCDBWebAPI.Infrastructure.CrossCutting.Adapter.Mapper;
using CalculoCDBWebAPI.Infrastructure.Repository.Repositorys;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculoCDBWebAPI.Infrastructure.CrossCutting.IOC
{
    public static class Extensions
    {
        public static IServiceCollection DependencyMap(this IServiceCollection services)
        {

            #region Application
            services.AddTransient<IApplicationServiceTaxa, ApplicationServiceTaxa>();
            #endregion

            #region Services
            services.AddTransient<IServiceTaxa, ServiceTaxa>();
            #endregion

            #region Repositorys
            services.AddTransient<IRepositoryTaxa, RepositoryTaxa>();
            #endregion

            #region Mapper
            services.AddTransient<IMapperTaxa, MapperTaxa>();
            #endregion

            return services;
        }
    }
}
