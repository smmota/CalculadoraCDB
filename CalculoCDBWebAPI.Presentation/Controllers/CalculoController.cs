using CalculoCDBWebAPI.Application.DTO.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CalculoCDBWebAPI.Presentation.Controllers
{
    [Route("api/calculadora")]
    [ApiController]
    public class CalculoController : ControllerBase
    {
        public CalculoController() { }

        [Route("CDB")]
        [EnableCors()]
        [HttpPost]
        public IActionResult CalcularCDB([FromBody] AplicacaoDto AplicacaoDto)
        {
            try
            {
                double txTB = 108.0;
                double txCDI = 0.9;

                CalculoDto calculo = new(AplicacaoDto.ValorAplicado, AplicacaoDto.QuantidadeMeses, txCDI, txTB);

                return Ok(calculo);
            }
            catch(ArgumentException ex)
            {
                return BadRequest($"Erro ao calcular o investimento! {ex.Message}");
            }
        }
    }
}
