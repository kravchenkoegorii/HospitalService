using HospitalService.Controllers.BaseController;
using HospitalService.Models;
using HospitalService.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HospitalService.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : BaseApiController
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        { 
            return Ok(await _patientService.GetPatients());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await _patientService.GetPatient(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return Ok(await _patientService.DeletePatient(id));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Patient patient)
        {
            return Created("", await _patientService.CreatePatient(patient));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromBody] Patient patient, int id)
        {
            return Ok(await _patientService.UpdatePatient(patient, id));
        }

        [HttpGet]
        public async Task<IActionResult> GetByDoctorSandagesAsync()
        {
            return Ok(await _patientService.GetPatientsOlderThan());
        }
    }
}