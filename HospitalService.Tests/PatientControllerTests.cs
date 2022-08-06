using HospitalService.Data;
using HospitalService.Exceptions;
using HospitalService.Models;
using HospitalService.Services;
using HospitalService.Services.Interfaces;
using Moq;
using Xunit;

namespace HospitalService.Tests
{
    public class PatientControllerTests
    {
        [Fact]
        public async Task CreatePatient_Older_Than_18()
        {
            // Arrange
            var patient = new Patient(1, "Egorka", "Kravch", 18, "bbb", 1);

            var mock = new Mock<IPatientRepository>();
            var mock1 = new Mock<IMessagePublisher>();

            mock.Setup(repo => repo.CreatePatient(patient).Result).Returns(patient);
            var service = new PatientService(mock.Object, mock1.Object);
            // Act

            // Assert
            var result = await Assert.ThrowsAsync<ValidateAgeException>(() =>
            service.CreatePatient(patient));
            Assert.Equal("Patient must be older 18", result.Message);
        }//failure

        [Fact]
        public async Task CreatePatient_Younger_Than_18()
        {
            //Arrange
            var patient = new Patient(1, "Egorka", "Kravch", 15, "bbb", 1);

            var mock = new Mock<IPatientRepository>();
            var mock1 = new Mock<IMessagePublisher>();

            mock.Setup(repo => repo.CreatePatient(patient).Result).Returns(patient);
            var service = new PatientService(mock.Object, mock1.Object);
            // Act

            // Assert
            var result = await Assert.ThrowsAsync<ValidateAgeException>(() =>
            service.CreatePatient(patient));
            Assert.Equal("Patient must be older 18", result.Message);
        }//true
    }
}