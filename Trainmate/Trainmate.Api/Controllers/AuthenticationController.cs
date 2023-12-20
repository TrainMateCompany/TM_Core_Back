using Microsoft.AspNetCore.Mvc;
using Trainmate.Common;
using Trainmate.Common.Dto;
using Trainmate.Domain.Interfaces.Login;
using Trainmate.Domain.Interfaces.Token;

namespace Trainmate.Api.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserLoginService _userLoginService;

        private readonly ICreateTokenService _createTokenService;
        private readonly IConfiguration _configuration;
        private readonly string token;


        public AuthenticationController(IUserLoginService userLoginService,
          ICreateTokenService createTokenService, IConfiguration configuration)
        {
            token = configuration.GetSection("Jwt:Token")?.Value;
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
