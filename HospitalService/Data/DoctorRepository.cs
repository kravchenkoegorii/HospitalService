using HospitalService.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalService.Data
{
    public class DoctorRepository:IDoctorRepository
    {
        private HospitalDbContext DbContext { get; set; }
        public DoctorRepository(HospitalDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public void ChangeDoctor(Doctor doctor, int id)
        {
            var toUpdate = DbContext.Doctors.Find(id);
            if (toUpdate != null)
                toUpdate = doctor;
            DbContext.Update(toUpdate);
            DbContext.SaveChanges();
        }

        public void CreateDoctor(Doctor doctor)
        {
            DbContext.Doctors.Add(doctor);
            DbContext.SaveChanges();
        }

        public void DeleteDoctor(int id)
        {
            var toDelete = DbContext.Doctors.Find(id);
            DbContext.Doctors.Remove(toDelete);
            DbContext.SaveChanges();
        }

        public Doctor GetDoctor(int id)
        {
            return DbContext.Doctors.Find(id);
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            return DbContext.Doctors.ToList();
        }
    }
}

