using HospitalService.Controllers.BaseController;
using HospitalService.Exceptions;
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
    public class DoctorController : BaseApiController
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        /// <summary>
        /// Returns list of all the doctors in database.
        /// </summary>
        [HttpGet]
        [SwaggerOperation(
            Summary = "Returns list of all the doctors in database.",
            Description = "Returns list of all the doctors in database.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _doctorService.GetDoctors());
        }

        /// <summary>
        /// Returns doctor by ID.
        /// </summary>
        /// <param name="id">ID of the doctor.</param>
        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Returns doctor by ID.", 
            Description = "Returns doctor by ID.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await _doctorService.GetDoctor(id));
        }

        /// <summary>
        /// Deletes doctor from database by ID.
        /// </summary>
        /// <param name="id">ID of the doctor.</param>
        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Deletes doctor from database by ID.",
            Description = "Deletes doctor from database by ID.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return Ok(await _doctorService.DeleteDoctor(id));
        }

        /// <summary>
        /// Adds new doctor to database.
        /// </summary>
        /// <param name="doctor">Doctor instance</param>
        [HttpPost]
        [SwaggerOperation(
            Summary = "Adds new doctor to database.", 
            Description = "Adds new doctor to database.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> PostAsync([FromBody] Doctor doctor)
        {
            return Created("", await _doctorService.CreateDoctor(doctor));
        }

        /// <summary>
        /// Modifies an existing doctor in database.
        /// </summary>
        /// <param name="doctor">Doctor instance</param>
        /// <param name="id">ID of the doctor</param>
        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Modifies an existing doctor in database.", 
            Description = "Modifies an existing doctor in database.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> PutAsync([FromBody] Doctor doctor, int id)
        {
            return Ok(await _doctorService.UpdateDoctor(doctor, id));
        }
    }
}