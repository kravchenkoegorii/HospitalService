using HospitalService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalService.Data
{
    public interface IDoctorRepository
    {
        public void CreateDoctor(Doctor doctor);

        public void DeleteDoctor(int id);

        public Doctor GetDoctor(int id);

        public IEnumerable<Doctor> GetDoctors();

        public void ChangeDoctor(Doctor doctor, int id);
    }
}