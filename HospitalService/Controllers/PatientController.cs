using HospitalService.Controllers.BaseController;
using HospitalService.Middleware;
using HospitalService.Models;
using HospitalService.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace HospitalService.Controllers
{
    [Authorize]
    [Produces("application/json")]
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
        [SwaggerOperation(
            Summary = "Returns list of all the patients in database.", 
            Description = "Returns list of all the patients in database.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _patientService.GetPatients());
        }

        /// <summary>
        /// Returns patient by ID.
        /// </summary>
        /// <param name="id">ID of the patient</param>
        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Returns patient by ID.", 
            Description = "Returns patient by ID.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await _patientService.GetPatient(id));
        }

        /// <summary>
        /// Deletes patient from database by ID.
        /// </summary>
        /// <param name="id">ID of the patient</param>
        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Deletes patient from database by ID.", 
            Description = "Deletes patient from database by ID.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return Ok(await _patientService.DeletePatient(id));
        }

        /// <summary>
        /// Adds new patient to database.
        /// </summary>
        /// <param name="patient">Patient instance</param>
        [HttpPost]
        [SwaggerOperation(
            Summary = "Adds new patient to database.", 
            Description = "Adds new patient to database.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> PostAsync([FromBody] Patient patient)
        {
            return Created("", await _patientService.CreatePatient(patient));
        }

        /// <summary>
        /// Modifies an existing patient in database.
        /// </summary>
        /// <param name="patient">Patient instance</param>
        /// <param name="id">ID of the patient</param>
        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Modifies an existing patient in database.", 
            Description = "Modifies an existing patient in database.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> PutAsync([FromBody] Patient patient, int id)
        {
            return Ok(await _patientService.UpdatePatient(patient, id));
        }
    }
}