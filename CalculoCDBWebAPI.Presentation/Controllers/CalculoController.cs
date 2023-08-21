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
        private readonly IApplicationServiceTaxa _serviceTaxa;

        public CalculoController(IApplicationServiceTaxa serviceTaxa)
        {
            _serviceTaxa = serviceTaxa;
        }

        [Route("CDB")]
        [EnableCors()]
        [HttpPost]
        public async Task<IActionResult> CalcularCDB([FromBody] AplicacaoDto AplicacaoDto)
        {
            try
            {
                if (AplicacaoDto.ValorAplicado <= 0)
                    ModelState.AddModelError("Valor Aplicado", "O valor aplicado não pode ser menor ou igual a zero");

                if (AplicacaoDto.QuantidadeMeses <= 1)
                    ModelState.AddModelError("Quantidade de Meses", "A quantidade de meses deve ser maior que um");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var taxas = await _serviceTaxa.GetAll();

                if (!taxas.Any() || taxas == null)
                    throw new Exception("Erro ao obter a taxas bases para o cálculo");

                double txCDI = Math.Round(taxas.First(x => x.Id == TaxaEnum.CDI.GetHashCode()).ValorPercentual, 1);
                double txTB = Math.Round(taxas.First(x => x.Id == TaxaEnum.TB.GetHashCode()).ValorPercentual, 1);

                CalculoDto calculo = new CalculoDto(AplicacaoDto.ValorAplicado, AplicacaoDto.QuantidadeMeses, txCDI, txTB);

                return Ok(calculo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
