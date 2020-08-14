using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using ProductSalesAPI.AuthServices;
using ProductSalesAPI.Models;

namespace ProductSalesAPI.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {

        private IAuthenticateService _authenticationService;

        public AuthorizationController(IAuthenticateService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] AuthUser model)
        {
            var user = _authenticationService.Authenticate(model.UserName, model.Password);

            if (user == null)
                return BadRequest(new { messega = "Username or password incorrect" });

            return Ok(user);
        }
    }
}
