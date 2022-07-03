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
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IPublishEndpoint _publishEndpoint;
        public PatientService(IPatientRepository patientRepository, IPublishEndpoint publishEndpoint)
        {
            _patientRepository = patientRepository;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<Patient> CreatePatient(Patient patient)
        {
            await _publishEndpoint.Publish<CreateObjectMessageDto>(new
            {
                patient.FirstName,
                patient.LastName,
                DateTime.Now,
                typeof(Patient).Name
            });
            return await _patientRepository.CreatePatient(patient);
        }

        public async Task<Patient> DeletePatient(int id)
        {
            return await _patientRepository.DeletePatient(id);
        }

        public async Task<List<Patient>> GetByDoctorSandages(int doctorId, int age)
        {
            return await _patientRepository.GetByDoctorSandages(doctorId, age);
        }

        public async Task<Patient> GetPatient(int id)
        {
            return await _patientRepository.GetPatient(id);
        }

        public async Task<List<Patient>> GetPatients()
        {
            return await _patientRepository.GetPatients();
        }

        public async Task<Patient> UpdatePatient(Patient patient, int id)
        {
            return await _patientRepository.UpdatePatient(patient, id);
        }
    }
}
