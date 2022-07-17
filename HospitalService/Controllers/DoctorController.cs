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
        [SwaggerOperation(Summary = "Returns list of all the doctors in database.")]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _doctorService.GetDoctors());
        }

        /// <summary>
        /// Returns doctor by id.
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id}", Name = "GetDoctorById")]
        [SwaggerOperation(Summary = "Returns doctor by id.")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await _doctorService.GetDoctor(id));
        }

        /// <summary>
        /// Deletes doctor from database by Id.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}", Name = "DeleteDoctorById")]
        [SwaggerOperation(Summary = "Deletes doctor from database by Id.")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return Ok(await _doctorService.DeleteDoctor(id));
        }

        /// <summary>
        /// Adds new doctor to database.
        /// </summary>
        /// <param name="doctor"></param>
        [HttpPost]
        [SwaggerOperation(Summary = "Adds new doctor to database.")]
        public async Task<IActionResult> PostAsync([FromBody] Doctor doctor)
        {
            return Created("", await _doctorService.CreateDoctor(doctor));
        }

        /// <summary>
        /// Modifies an existing doctor in database.
        /// </summary>
        /// <param name="doctor"></param>
        /// <param name="id"></param>
        [HttpPut("{id}", Name = "UpdateDoctor")]
        [SwaggerOperation(Summary = "Modifies an existing doctor in database.")]
        public async Task<IActionResult> PutAsync([FromBody] Doctor doctor, int id)
        {
            return Ok(await _doctorService.UpdateDoctor(doctor, id));
        }
    }
}