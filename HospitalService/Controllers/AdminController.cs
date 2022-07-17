using HospitalService.Controllers.BaseController;
using HospitalService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace HospitalService.Controllers
{
    public class AdminController : BaseApiController
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        /// <summary>
        /// Returns admin by id.
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id}", Name = "GetAdminById")]
        [SwaggerOperation(Summary = "Returns admin by id.")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await _adminService.GetAdmin(id));
        }

        /// <summary>
        /// Returns list of all the admins in database.
        /// </summary>
        [HttpGet]
        [SwaggerOperation(Summary = "Returns list of all the admins in database.")]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _adminService.GetAdmins());
        }
    }
}
