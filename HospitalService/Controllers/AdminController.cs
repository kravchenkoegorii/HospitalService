using HospitalService.Controllers.BaseController;
using HospitalService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await _adminService.GetAdmin(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _adminService.GetAdmins());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return Ok(await _adminService.DeleteAdmin(id));
        }
    }
}
