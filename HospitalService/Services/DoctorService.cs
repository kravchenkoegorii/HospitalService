using HospitalService.Data;
using HospitalService.Models;
using HospitalService.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalService.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMessagePublisher _messagePublisher;
        public DoctorService(IDoctorRepository doctorRepository, IMessagePublisher messagePublisher)
        {
            _doctorRepository = doctorRepository;
            _messagePublisher = messagePublisher;
        }

        public async Task<Doctor> CreateDoctor(Doctor doctor)
        {
            await _messagePublisher.SendMessageAsync($"Doc {doctor.FirstName} {doctor.LastName} was created in {DateTime.Now}", "message-queue");
            return await _doctorRepository.CreateDoctor(doctor);
        }

        public async Task<Doctor> DeleteDoctor(int id)
        {
            return await _doctorRepository.DeleteDoctor(id);
        }

        public async Task<Doctor> GetDoctor(int id)
        {
            await _messagePublisher.SendMessageAsync($"Doc was created in акукаа", "message-queue");
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
