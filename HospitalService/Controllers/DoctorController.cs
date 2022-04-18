using HospitalService.Data;
using HospitalService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly HospitalDbContext _dbContext;

        public DoctorController(IDoctorRepository doctorRepository, HospitalDbContext dbContext)
        {
            _doctorRepository = doctorRepository;
            _dbContext = dbContext;
        }

        // GET: api/Doctors
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _doctorRepository.GetDoctors();
            
            return Ok(result);
        }

        // GET: api/Doctors/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _doctorRepository.GetDoctor(id);
            return Ok(result);
        }

        // DELETE: api/Doctors/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _doctorRepository.DeleteDoctor(id);
            return Ok(result);
        }
        
        // POST: api/Doctors
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromQuery]Doctor doctor)
        {
            var result = await _doctorRepository.CreateDoctor(doctor);
            return Created("", result);
        }

        // PUT: api/Doctors/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromQuery]Doctor doctor, int id)
        {
            var result = await _doctorRepository.UpdateDoctor(doctor, id);
            return Ok(result);
        }

    }

}