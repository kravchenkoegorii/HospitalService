using HospitalService.Controllers.BaseController;
using HospitalService.Middleware;
using HospitalService.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace HospitalService.Controllers
{
    [Authorize]
    [Produces("application/json")]
    public class AdminController : BaseApiController
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        /// <summary>
        /// Returns admin by ID.
        /// </summary>
        /// <param name="id">ID of the admin</param>
        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Returns admin by ID.", 
            Description = "Returns admin by ID.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await _adminService.GetAdmin(id));
        }

        /// <summary>
        /// Returns list of all the admins in database.
        /// </summary>
        [HttpGet]
        [SwaggerOperation(
            Summary = "Returns list of all the admins in database.",
            Description = "Returns list of all the admins in database.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _adminService.GetAdmins());
        }
    }
}
