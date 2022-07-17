using HospitalService.Data;
using HospitalService.DTOs;
using HospitalService.Exceptions;
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
        private readonly IEventSender _eventSender;
        public PatientService(IPatientRepository patientRepository, IEventSender eventSender)
        {
            _patientRepository = patientRepository;
            _eventSender = eventSender;
        }

        public async Task<Patient> CreatePatient(Patient patient)
        {
            if (!patient.ValidateAge())
                throw new ValidateAgeException("Patient must be older 18");
            await _eventSender.SendMessage($"Patient {patient.FirstName} {patient.LastName} was created in {DateTime.Now}");
            return await _patientRepository.CreatePatient(patient);
        }

        public async Task<Patient> DeletePatient(int id)
        {
            return await _patientRepository.DeletePatient(id);
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
            if (!patient.ValidateAge())
                throw new ValidateAgeException("Patient must be older 18");
            return await _patientRepository.UpdatePatient(patient, id);
        }
    }
}
