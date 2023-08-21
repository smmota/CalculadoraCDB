using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculoCDBWebAPI.Application.DTO.DTO
{
    public class AplicacaoDto
    {
        [Required(ErrorMessage = "Informe o valor aplicado")]
        public Decimal? ValorAplicado { get; set; }

        [Required(ErrorMessage = "Informe a quantidade de meses")]
        public int? QuantidadeMeses { get; set; }
    }
}
