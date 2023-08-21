using CalculoCDBWebAPI.Domain.Core.Interfaces.Repositorys;
using CalculoCDBWebAPI.Domain.Models;
using CalculoCDBWebAPI.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculoCDBWebAPI.Infrastructure.Repository.Repositorys
{
    public class RepositoryTaxa : RepositoryBase<Taxa>, IRepositoryTaxa
    {
        private readonly SqlContext _context;

        public RepositoryTaxa(SqlContext context) : base(context)
        {
            _context = context;
        }
    }
}
