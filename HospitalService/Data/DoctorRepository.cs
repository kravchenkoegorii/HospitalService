using HospitalService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalService.Data
{
    public class DoctorRepository: IDoctorRepository
    {
        private readonly HospitalDbContext _dbContext;

        public DoctorRepository(HospitalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Doctor> ChangeDoctor(Doctor doctor, int id)
        {
            var toUpdate = await _dbContext.Doctors.FindAsync(id);
            if (toUpdate != null)
                toUpdate = doctor;
            _dbContext.Update(toUpdate);
            await _dbContext.SaveChangesAsync();
            return toUpdate;
        }

        public async Task<Doctor> CreateDoctor(Doctor doctor)
        {
            _dbContext.Doctors.Add(doctor);
            await _dbContext.SaveChangesAsync();
            return doctor;
        }

        public async Task<Doctor> DeleteDoctor(int id)
        {
            var toDelete = await _dbContext.Doctors.FindAsync(id);
            _dbContext.Doctors.Remove(toDelete);
            await _dbContext.SaveChangesAsync();
            return toDelete;
        }

        public async Task<Doctor> GetDoctor(int id)
        {
            var doctor = await _dbContext.Doctors.FindAsync(id);
            return doctor;
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            var doctors = await _dbContext.Doctors.ToListAsync();
            return doctors;
        }
    }
}

