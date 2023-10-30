using Bios_Back.Common.Dto;
using Bios_Back.Common;
using Bios_Back.Domain.Interfaces.Login;
using Bios_Back.Domain.Interfaces.Token;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bios_Back.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserLoginService _userLoginService;

        private readonly ICreateTokenService _createTokenService;
        private readonly IConfiguration _configuration;


        public AuthenticationController(IUserLoginService userLoginService,
          ICreateTokenService createTokenService, IConfiguration configuration)
        {
            _userLoginService = userLoginService;
            _createTokenService = createTokenService;
            _configuration = configuration;
        }

        /// <summary>
        /// User Login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto login)
        {
            var result = await _userLoginService.Execute(login);
            if (result.HasErrors)
            {
                return BadRequest(result.Errors);
            }

            Logs.WriteInfoLog($"Login successful. User: [{login.UserName}].");
            return Ok(new
            {
                token = result.Result
            });
        }

    }
}
