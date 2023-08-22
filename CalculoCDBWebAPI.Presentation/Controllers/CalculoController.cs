using CalculoCDBWebAPI.Application.DTO.DTO;
using CalculoCDBWebAPI.Application.Interfaces;
using CalculoCDBWebAPI.Presentation.Enumarations;
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
                if (AplicacaoDto.ValorAplicado <= 0)
                    ModelState.AddModelError("Valor Aplicado", "O valor aplicado não pode ser menor ou igual a zero");

                if (AplicacaoDto.QuantidadeMeses <= 1)
                    ModelState.AddModelError("Quantidade de Meses", "A quantidade de meses deve ser maior que um");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                double txTB = Math.Round(Convert.ToDouble(108), 1);
                double txCDI = Math.Round(Convert.ToDouble(0.9), 1);

                CalculoDto calculo = new CalculoDto(AplicacaoDto.ValorAplicado, AplicacaoDto.QuantidadeMeses, txCDI, txTB);

                return Ok(calculo);
            }
            catch
            {
                return BadRequest("Erro ao calcular o investimento!");
            }
        }
    }
}
