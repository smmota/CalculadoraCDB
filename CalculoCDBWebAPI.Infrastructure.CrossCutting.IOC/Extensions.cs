using CalculoCDBWebAPI.Domain.Core.Interfaces.Repositorys;
using CalculoCDBWebAPI.Domain.Core.Interfaces.Services;
using CalculoCDBWebAPI.Domain.Services.Services;
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
            
            #endregion

            #region Services
            
            #endregion

            #region Repositorys
            
            #endregion

            #region Mapper
            
            #endregion

            return services;
        }
    }
}
