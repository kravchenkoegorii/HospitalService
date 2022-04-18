using HospitalService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalService.Data
{
    public interface IDoctorRepository
    {

        Task<Doctor> CreateDoctor(Doctor doctor);

        Task<Doctor> DeleteDoctor(int id);

        Task<Doctor> GetDoctor(int id);

        Task<List<Doctor>> GetDoctors();

        Task<Doctor> UpdateDoctor(Doctor doctor, int id);
    }
}