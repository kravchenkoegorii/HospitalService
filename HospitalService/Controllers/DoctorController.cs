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
        [SwaggerOperation(Summary = "Returns list of all the doctors in database.", Description = "Returns list of all the doctors in database.")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _doctorService.GetDoctors());
        }

        /// <summary>
        /// Returns doctor by ID.
        /// </summary>
        /// <param name="id">ID of the doctor.</param>
        [HttpGet("{id}", Name = "GetDoctorById")]
        [SwaggerOperation(Summary = "Returns doctor by id.", Description = "Returns doctor by id.")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await _doctorService.GetDoctor(id));
        }

        /// <summary>
        /// Deletes doctor from database by ID.
        /// </summary>
        /// <param name="id">ID of the doctor.</param>
        [HttpDelete("{id}", Name = "DeleteDoctorById")]
        [SwaggerOperation(Summary = "Deletes doctor from database by Id.", Description = "Deletes doctor from database by Id.")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return Ok(await _doctorService.DeleteDoctor(id));
        }

        /// <summary>
        /// Adds new doctor to database.
        /// </summary>
        /// <param name="doctor">Doctor instance</param>
        [HttpPost]
        [SwaggerOperation(Summary = "Adds new doctor to database.", Description = "Adds new doctor to database.")]
        public async Task<IActionResult> PostAsync([FromBody] Doctor doctor)
        {
            return Created("", await _doctorService.CreateDoctor(doctor));
        }

        /// <summary>
        /// Modifies an existing doctor in database.
        /// </summary>
        /// <param name="doctor">Doctor instance</param>
        /// <param name="id">ID of the doctor</param>
        [HttpPut("{id}", Name = "UpdateDoctor")]
        [SwaggerOperation(Summary = "Modifies an existing doctor in database.", Description = "Modifies an existing doctor in database.")]
        public async Task<IActionResult> PutAsync([FromBody] Doctor doctor, int id)
        {
            return Ok(await _doctorService.UpdateDoctor(doctor, id));
        }
    }
}