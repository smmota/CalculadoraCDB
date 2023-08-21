using Autofac;
using CalculoCDBWebAPI.Application.Interfaces;
using CalculoCDBWebAPI.Application.Service;
using CalculoCDBWebAPI.Domain.Core.Interfaces.Repositorys;
using CalculoCDBWebAPI.Domain.Core.Interfaces.Services;
using CalculoCDBWebAPI.Infrastructure.CrossCutting.Adapter.Interfaces;
using CalculoCDBWebAPI.Infrastructure.CrossCutting.Adapter.Mapper;
using CalculoCDBWebAPI.Infrastructure.Repository.Repositorys;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CalculoCDBWebAPI.Infrastructure.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region Application

            builder.RegisterType<ApplicationServiceTaxa>().As<IApplicationServiceTaxa>();

            #endregion

            #region Services

            builder.RegisterType<IServiceTaxa>().As<IServiceTaxa>();

            #endregion

            #region Repositorys

            builder.RegisterType<RepositoryTaxa>().As<IRepositoryTaxa>();

            #endregion

            #region Mapper

            builder.RegisterType<MapperTaxa>().As<IMapperTaxa>();
            
            #endregion
        }
    }
}
