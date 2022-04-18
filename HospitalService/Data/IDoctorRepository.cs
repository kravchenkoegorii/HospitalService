using HospitalService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalService.Data
{
    public interface IDoctorRepository
    {

        public Task<IActionResult> CreateDoctor(Doctor doctor);

        public Task<IActionResult> DeleteDoctor(int id);

        public Task<IActionResult> GetDoctor(int id);

        public Task<IActionResult> GetDoctors();

        public Task<IActionResult> ChangeDoctor(Doctor doctor, int id);
    }
}