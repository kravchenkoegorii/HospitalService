using HospitalService.Data;
using HospitalService.Models;
using System.Collections.Generic;

namespace HospitalService.Controllers
{
    public class DoctorController: IDoctorRepository
    {
        private HospitalDbContext DbContext { get; set; }
        private List<Doctor> _doctors;

        public DoctorController(HospitalDbContext dbContext)
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