using Case.Itau.Business.Models.V1;
using Case.Itau.Business.Services.V1.Fundos;
using Microsoft.AspNetCore.Mvc;

namespace Case.Itau.Api.Controllers.V1.Fundos
{
    [ApiExplorerSettings(GroupName = "v1.Fundos")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FundoController : ControllerBase
    {
        private readonly IFundosServices fundosServices;

        public FundoController(IFundosServices fundosServices)
        {
            this.fundosServices = fundosServices;
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FundosResult))]
        public async Task<IActionResult> ObterFundos()
        {
            return Ok(await fundosServices.ObterFundos());
        }

        [HttpGet("{codigo}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FundosResult))]
        public async Task<IActionResult> ObterFundos(string codigo)
        {
            return Ok(await fundosServices.ObterFundo(codigo));
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FundoModel))]
        public async Task<IActionResult> InserirFundo([FromBody] FundoModel fundoModel)
        {
            await fundosServices.Inserir(fundoModel);
            return Ok();
        }

        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FundoModel))]
        public async Task<IActionResult> AlterarFundo([FromBody] FundoModel fundoModel)
        {
            await fundosServices.Alterar(fundoModel);
            return Ok();
        }

        [HttpDelete()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FundoModel))]
        public async Task<IActionResult> DeletarFundo(string codigo)
        {
            await fundosServices.Deletar(codigo);
            return Ok();
        }
    }
}
