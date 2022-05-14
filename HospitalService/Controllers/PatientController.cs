using HospitalService.Data;
using HospitalService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;
        private readonly HospitalDbContext _dbContext;

        public PatientController(IPatientRepository patientRepository, HospitalDbContext dbContext)
        {
            _patientRepository = patientRepository;
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _patientRepository.GetPatients();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _patientRepository.GetPatient(id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _patientRepository.DeletePatient(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Patient patient)
        {
            var result = await _patientRepository.CreatePatient(patient);
            return Created("", result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromBody] Patient patient, int id)
        {
            var result = await _patientRepository.UpdatePatient(patient, id);
            return Ok(result);
        }

        [HttpGet("getbydoctorsandages/{doctorId}")]
        public async Task<IActionResult> GetByDoctorSandagesAsync(int doctorId, [FromQuery] int age)
        {
            var result = await _patientRepository.GetByDoctorSandages(doctorId, age);
            return Ok(result);
        }
    }
}