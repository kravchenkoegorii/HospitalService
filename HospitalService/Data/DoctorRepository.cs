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

        public async Task<Doctor> UpdateDoctor(Doctor doctor, int id)
        {
            var foundDoctor = await _dbContext.Doctors.FindAsync(id);
            //if(foundDoctor != null)
                doctor.Id = id;
            //_dbContext.Update(doctor);
            await _dbContext.SaveChangesAsync();
            return doctor;
        }

        public async Task<Doctor> CreateDoctor(Doctor doctor)
        {
            await _dbContext.Doctors.AddAsync(doctor);
            await _dbContext.SaveChangesAsync();
            return doctor;
        }

        public async Task<Doctor> DeleteDoctor(int id)
        {
            var doctor = await _dbContext.Doctors.FindAsync(id);
            _dbContext.Doctors.Remove(doctor);
            await _dbContext.SaveChangesAsync();
            return doctor;
        }

        public async Task<Doctor> GetDoctor(int id)
        {
            return await _dbContext.Doctors.FindAsync(id);         
        }

        public async Task<List<Doctor>> GetDoctors()
        {
            return await _dbContext.Doctors.ToListAsync();
        }
    }
}

