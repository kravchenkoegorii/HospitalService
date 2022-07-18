using HospitalService.Exceptions;
using HospitalService.Models;
using Microsoft.EntityFrameworkCore;
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
            if(foundDoctor == null)
            {
                throw new NotFoundException("This doctor does not exist!");
            }
            doctor.Id = id;
            _dbContext.Update(doctor);
            _dbContext.Entry(doctor).State = EntityState.Modified;
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
            if(doctor == null)
            {
                throw new NotFoundException("This doctor does not exist");
            }
            _dbContext.Doctors.Remove(doctor);
            await _dbContext.SaveChangesAsync();
            return doctor;
        }

        public async Task<Doctor> GetDoctor(int id)
        {
            return await _dbContext.Doctors.Where(d => d.Id == id)
                        .Include(d => d.Patients)
                        .FirstOrDefaultAsync();
        }

        public async Task<List<Doctor>> GetDoctors()
        {
            return await _dbContext.Doctors.ToListAsync();
        }
    }
}

