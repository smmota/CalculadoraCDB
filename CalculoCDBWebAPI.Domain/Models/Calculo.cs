using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculoCDBWebAPI.Domain.Models
{
    public class Calculo : Base
    {
        public Decimal ValorAplicado { get; set; }
        public int QuantidadeMeses { get; set; }
        public Decimal ValorBruto { get; set; }
        public Decimal ValorLiquido { get; set; }
    }
}
