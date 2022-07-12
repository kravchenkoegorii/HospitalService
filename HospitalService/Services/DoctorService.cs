using HospitalService.Data;
using HospitalService.DTOs;
using HospitalService.Models;
using HospitalService.RabbitMQ;
using HospitalService.Services.Interfaces;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalService.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IEventSender _eventSender;

        public DoctorService(IDoctorRepository doctorRepository, IEventSender eventSender)
        {
            _doctorRepository = doctorRepository;
            _eventSender = eventSender;
        }

        public async Task<Doctor> CreateDoctor(Doctor doctor)
        {
            await _eventSender.SendMessage($"Doc {doctor.FirstName} {doctor.LastName} was created in {DateTime.Now}");
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
