using HospitalService.Controllers.BaseController;
using HospitalService.Data;
using HospitalService.DTOs;
using HospitalService.Models;
using HospitalService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HospitalService.Controllers
{
    public class AccountController : BaseApiController
    {

        private readonly IAuthorizationService _authorizationService;

        public AccountController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        /// <summary>
        /// Register new admin.
        /// </summary>
        /// <param name="registerDto"></param>
        [HttpPost("register")]
        [SwaggerOperation(
            Description = "Registers user in the system.",
            Summary = "Registers user in the system.")]
        public async Task<ActionResult<AdminDto>> Register(RegisterDto registerDto)
        {
            if (await _authorizationService.AdminExists(registerDto.Username))
                return BadRequest("Username is taken!");

            return Ok(await _authorizationService.Register(registerDto));
        }

        /// <summary>
        /// Log into admin`s account.
        /// </summary>
        /// <param name="loginDto"></param>
        [HttpPost("login")]
        [SwaggerOperation(
            Summary = "Logs into admin`s account.",
            Description = "Logs into admin`s account"
            )]
        public async Task<ActionResult<AdminDto>> Login(LoginDto loginDto)
        {
            return Ok(await _authorizationService.Login(loginDto));
        }
    }
}
