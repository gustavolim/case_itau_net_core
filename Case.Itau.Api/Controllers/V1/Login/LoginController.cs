using Case.Itau.Business.Services.V1.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Case.Itau.Api.Controllers.V1.Login
{
    [ApiExplorerSettings(GroupName = "v1.Login")]
    [Route("api/v1/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly ILogin _login;

        public LoginController(ILogin login) => _login = login;

        [HttpPost("login")]
        public IActionResult Login()
        {
            var token = _login.GerarToken();
            return Ok(new { Token = token });
        }
    }
}
