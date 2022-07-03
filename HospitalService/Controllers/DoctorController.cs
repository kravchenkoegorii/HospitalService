using HospitalService.Controllers.BaseController;
using HospitalService.Data;
using HospitalService.Models;
using HospitalService.RabbitMQ;
using HospitalService.Services.Interfaces;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalService.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : BaseApiController
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        // GET: api/Doctors
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _doctorService.GetDoctors());
        }

        // GET: api/Doctors/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await _doctorService.GetDoctor(id));
        }

        // DELETE: api/Doctors/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return Ok(await _doctorService.DeleteDoctor(id));
        }

        // POST: api/Doctors
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Doctor doctor)
        {
            return Created("", await _doctorService.CreateDoctor(doctor));
        }

        // PUT: api/Doctors/id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromBody] Doctor doctor, int id)
        {
            return Ok(await _doctorService.UpdateDoctor(doctor, id));
        }
    }
}