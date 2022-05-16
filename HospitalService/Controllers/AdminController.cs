using HospitalService.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalService.Controllers
{
    public class AdminController : BaseApiController
    {
        private readonly IAdminRepository _adminRepository;

        public AdminController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _adminRepository.GetAdmin(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _adminRepository.GetAdmins();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _adminRepository.DeleteAdmin(id);
            return Ok(result);
        }
    }
}
