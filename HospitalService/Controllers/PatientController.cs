using HospitalService.Controllers.BaseController;
using HospitalService.Models;
using HospitalService.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
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

        /// <summary>
        /// Returns list of all the patients in database.
        /// </summary>
        [HttpGet]
        [SwaggerOperation(Summary = "Returns list of all the patients in database.", Description = "Returns list of all the patients in database.")]
        public async Task<IActionResult> GetAsync()
        { 
            return Ok(await _patientService.GetPatients());
        }

        /// <summary>
        /// Returns patient by id.
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id}", Name = "GetPatientById")]
        [SwaggerOperation(Summary = "Returns patient by id.", Description = "Returns patient by id.")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await _patientService.GetPatient(id));
        }

        /// <summary>
        /// Deletes patient from database by Id.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}", Name = "DeletePatientById")]
        [SwaggerOperation(Summary = "Deletes patient from database by Id.", Description = "Deletes patient from database by Id.")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return Ok(await _patientService.DeletePatient(id));
        }

        /// <summary>
        /// Adds new patient to database.
        /// </summary>
        /// <param name="patient"></param>
        [HttpPost]
        [SwaggerOperation(Summary = "Adds new patient to database.", Description = "Adds new patient to database.")]
        public async Task<IActionResult> PostAsync([FromBody] Patient patient)
        {
            return Created("", await _patientService.CreatePatient(patient));
        }

        /// <summary>
        /// Modifies an existing patient in database.
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="id"></param>
        [HttpPut("{id}", Name = "UpdatePatient")]
        [SwaggerOperation(Summary = "Modifies an existing patient in database.", Description = "Modifies an existing patient in database.")]
        public async Task<IActionResult> PutAsync([FromBody] Patient patient, int id)
        {
            return Ok(await _patientService.UpdatePatient(patient, id));
        }
    }
}