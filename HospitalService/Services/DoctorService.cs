using HospitalService.Data;
using HospitalService.Models;
using HospitalService.Services.Interfaces;
using HospitalService.Services.ServiceBusMessaging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalService.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IServiceBusSender _messagePublisher;
        public DoctorService(IDoctorRepository doctorRepository, IServiceBusSender messagePublisher)
        {
            _doctorRepository = doctorRepository;
            _messagePublisher = messagePublisher;
        }

        public async Task<Doctor> CreateDoctor(Doctor doctor)
        {
            await _messagePublisher.SendMessageAsync($"Doc {doctor.FirstName} {doctor.LastName} was created in {DateTime.Now}");
            return await _doctorRepository.CreateDoctor(doctor);
        }

        public async Task<Doctor> DeleteDoctor(int id)
        {
            return await _doctorRepository.DeleteDoctor(id);
        }

        public async Task<Doctor> GetDoctor(int id)
        {
            return await _doctorRepository.GetDoctor(id);
        }

        public async Task<List<Doctor>> GetDoctors()
        {
            return await _doctorRepository.GetDoctors();
        }

        public async Task<Doctor> UpdateDoctor(Doctor doctor, int id)
        {
            return await _doctorRepository.UpdateDoctor(doctor, id);
        }
    }
}
