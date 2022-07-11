using HospitalService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalService.Services.Interfaces
{
    public interface IPatientService
    {
        Task<Patient> CreatePatient(Patient patient);
        Task<Patient> GetPatient(int id);
        Task<List<Patient>> GetPatients();
        Task<Patient> DeletePatient(int id);
        Task<Patient> UpdatePatient(Patient patient, int id);
        Task<List<Patient>> GetPatientsOlderThan();
    }
}
