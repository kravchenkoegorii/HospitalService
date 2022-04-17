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
        private readonly HospitalDbContext _dbContext;

        public DoctorController(HospitalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Doctors
        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            var doctors = await _dbContext.Doctors.ToListAsync();
            return Ok(doctors);
        }

        // GET: api/Doctors/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctor(int id)
        {
            var doctor = await _dbContext.Doctors.FindAsync(id);
            if (doctor == null)
                return NotFound();
            return Ok(doctor);
        }

        // DELETE: api/Doctors/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var doctor = await _dbContext.Doctors.FindAsync(id);
            if (doctor == null)
                return NotFound();
            _dbContext.Doctors.Remove(doctor);
            await _dbContext.SaveChangesAsync();
            return Ok(doctor);
        }
        
        // POST: api/Doctors
        [HttpPost]
        public async Task<IActionResult> CreateDoctor(Doctor doctor)
        {
            if (doctor == null)
                return BadRequest();
            _dbContext.Doctors.Add(doctor);
            await _dbContext.SaveChangesAsync();
            return Ok(doctor);
        }

        // PUT: api/Doctors/2
        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeDoctor(Doctor doctor, int id)
        {
            if (id != doctor.Id)
            {
                return BadRequest();
            }
            _dbContext.Doctors.Update(doctor);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

    }

}