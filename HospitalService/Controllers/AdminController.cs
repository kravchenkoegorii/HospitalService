using HospitalService.Controllers.BaseController;
using HospitalService.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        [HttpGet("{id}", Name = "GetAdminById")]
        [SwaggerOperation(Summary = "Returns admin by id.", Description = "Returns admin by id.")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await _adminService.GetAdmin(id));
        }

        /// <summary>
        /// Returns list of all the admins in database.
        /// </summary>
        [HttpGet]
        //[SwaggerOperation(Summary = "Returns list of all the admins in database.", Description = "Returns list of all the admins in database.")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _adminService.GetAdmins());
        }
    }
}
