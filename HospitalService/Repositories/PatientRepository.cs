using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalService.Exceptions;
using HospitalService.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalService.Data
{
    public class PatientRepository : IPatientRepository
    {
        private readonly HospitalDbContext _dbContext;

        public PatientRepository(HospitalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Patient> CreatePatient(Patient patient)
        {
            await _dbContext.AddAsync(patient);
            await _dbContext.SaveChangesAsync();
            return patient;
        }

        public async Task<Patient> DeletePatient(int id)
        {
            var patient = await _dbContext.Patients.FindAsync(id);

            if (patient == null)
            {
                throw new NotFoundException("This patient does not exist!");
            }

            _dbContext.Remove(patient);
            await _dbContext.SaveChangesAsync();
            return patient;
        }

        public async Task<Patient> GetPatient(int id)
        {
            return await _dbContext.Patients.FindAsync(id);
        }

        public async Task<List<Patient>> GetPatients()
        {
            return await _dbContext.Patients.ToListAsync();
        }

        public async Task<Patient> UpdatePatient(Patient patient, int id)
        {
            var foundPatient = await _dbContext.Patients.FindAsync(id);

            if (foundPatient == null)
            {
                throw new NotFoundException("This patient does not exist!");
            }

            patient.Id = id;
            _dbContext.Update(patient);
            _dbContext.Entry(patient).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return patient;
        }
    }
}