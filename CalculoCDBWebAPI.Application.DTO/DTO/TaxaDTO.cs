using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculoCDBWebAPI.Application.DTO.DTO
{
    public class TaxaDto
    {
        public int? Id { get; set; }
        public string? Descricao { get; set; }
        public Double ValorPercentual { get; set; }
    }
}
