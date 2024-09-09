namespace Case.Itau.BFF.Controllers
{
    using Case.Itau.BFF.DTOs;
    using Case.Itau.BFF.Services;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class FundosController : ControllerBase
    {
        private readonly IFundoService _fundoService;

        public FundosController(IFundoService fundoService)
        {
            _fundoService = fundoService;
        }

        [HttpGet("{codigo}")]
        public async Task<IActionResult> GetFundo(string codigo)
        {
            var fundo = await _fundoService.GetFundoAsync(codigo);
            return Ok(fundo);
        }

        [HttpGet]
        public async Task<IActionResult> GetFundos()
        {
            var fundos = await _fundoService.GetFundosAsync();
            return Ok(fundos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFundo(FundoRequest fundo)
        {
            await _fundoService.CreateFundoAsync(fundo);
            return CreatedAtAction(nameof(GetFundo), new { codigo = fundo.Codigo }, fundo);
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateFundo(FundoRequest fundo)
        {
            await _fundoService.UpdateFundoAsync(fundo);
            return NoContent();
        }

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> DeleteFundo(string codigo)
        {
            await _fundoService.DeleteFundoAsync(codigo);
            return NoContent();
        }
    }

}
