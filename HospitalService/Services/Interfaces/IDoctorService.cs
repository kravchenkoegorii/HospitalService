using HospitalService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalService.Services.Interfaces
{
    public interface IDoctorService
    {
        Task<Doctor> CreateDoctor(Doctor doctor);

        Task<Doctor> DeleteDoctor(int id);

        Task<Doctor> GetDoctor(int id);

        Task<List<Doctor>> GetDoctors();

        Task<Doctor> UpdateDoctor(Doctor doctor, int id);
    }
}
