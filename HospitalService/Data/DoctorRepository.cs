using HospitalService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalService.Data
{
    public class DoctorRepository:IDoctorRepository
    {
        private HospitalDbContext DbContext { get; set; }
        private List<Doctor> _doctors;
        public DoctorRepository(HospitalDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public void ChangeDoctor(Doctor doctor, int id)
        {
            _doctors[id] = doctor;
        }

        public void CreateDoctor(Doctor doctor)
        {
            _doctors.Add(doctor);
        }

        public void DeleteDoctor(int id)
        {
            _doctors.RemoveAt(id);
        }

        public Doctor GetDoctor(int id)
        {
            return _doctors[id];
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            return _doctors;
        }
    }
}

