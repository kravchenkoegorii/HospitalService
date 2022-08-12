using HospitalService.Controllers.BaseController;
using HospitalService.DTOs;
using HospitalService.Middleware;
using HospitalService.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace HospitalService.Controllers
{
    [Produces("application/json")]
    public class AccountController : BaseApiController
    {

        private readonly IAuthorizationService _authorizationService;

        public AccountController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        /// <summary>
        /// Registers new admin.
        /// </summary>
        /// <param name="registerDto">RegisterDto instance</param>
        [HttpPost("register")]
        [SwaggerOperation(
            Description = "Registers new admin.",
            Summary = "Registers new admin.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AdminDto>> Register(RegisterDto registerDto)
        {
            if (await _authorizationService.AdminExists(registerDto.Username))
                return BadRequest("Username is taken!");

            return Ok(await _authorizationService.Register(registerDto));
        }

        /// <summary>
        /// Logs into admin`s account.
        /// </summary>
        /// <param name="loginDto">LoginDto instance</param>
        [HttpPost("login")]
        [SwaggerOperation(
            Summary = "Logs into admin`s account.",
            Description = "Logs into admin`s account."
            )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AdminDto>> Login(LoginDto loginDto)
        {
            return Ok(await _authorizationService.Login(loginDto));
        }
    }
}
