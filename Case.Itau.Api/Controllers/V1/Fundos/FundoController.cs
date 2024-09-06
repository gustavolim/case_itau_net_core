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
    }
}
