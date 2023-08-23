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
                if (AplicacaoDto.ValorAplicado <= 0)
                    ModelState.AddModelError("Valor Aplicado", "O valor aplicado não pode ser menor ou igual a zero");

                if (AplicacaoDto.QuantidadeMeses <= 1)
                    ModelState.AddModelError("Quantidade de Meses", "A quantidade de meses deve ser maior que um");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                double txTB = Convert.ToDouble(108);
                double txCDI = Convert.ToDouble(0.9);

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
