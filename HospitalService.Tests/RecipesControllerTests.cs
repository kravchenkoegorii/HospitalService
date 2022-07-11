using Xunit;
using HospitalService.Controllers;
using HospitalService.Models;
using HospitalService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using HospitalService.Data;
using HospitalService.Services;
using FakeItEasy;
using Moq;
using MassTransit;

namespace HospitalService.Tests
{    public class RecipesControllerTests
    {
        [Fact]
        public void GetPatients_Older_Than_18()
        {
            /*var expected = Expected();

            var patients = Actual();*/
            var patients = new List<Patient>
            {
                new Patient(1, "Egorka", "Kravch", 16, "bbb", 1),
                new Patient(2, "Egorka", "Kravch", 21, "bbb", 1),
                new Patient(3, "Egorka", "Kravch", 15, "bbb", 1),
                new Patient(4, "Egorka", "Kravch", 20, "bbb", 1),
                new Patient(5, "Egorka", "Kravch", 100, "bbb", 1),
                new Patient(6, "Egorka", "Kravch", 30, "bbb", 1)
            };
            var expected = new List<Patient>
            {
                new Patient(2, "Egorka", "Kravch", 21, "bbb", 1),
                new Patient(4, "Egorka", "Kravch", 20, "bbb", 1),
                new Patient(5, "Egorka", "Kravch", 100, "bbb", 1),
                new Patient(6, "Egorka", "Kravch", 30, "bbb", 1)
            };

            // Arrange

            var mock = new Mock<IPatientRepository>();
            var mock1 = new Mock<IPublishEndpoint>();

            mock.Setup(repo => repo.GetPatientsOlderThan18().Result).Returns(expected);
            var service = new PatientService(mock.Object, mock1.Object);

            // Act

            var actual = service.GetPatientsOlderThan();

            // Assert

            Assert.Equal(expected, actual.Result);
        }//true test

        [Fact]
        public void GetPatients_Younger_Than_18()//error test
        {
            var patients = new List<Patient>
            {
                new Patient(1, "Egorka", "Kravch", 16, "bbb", 1),
                new Patient(2, "Egorka", "Kravch", 21, "bbb", 1),
                new Patient(3, "Egorka", "Kravch", 15, "bbb", 1),
                new Patient(4, "Egorka", "Kravch", 20, "bbb", 1),
                new Patient(5, "Egorka", "Kravch", 100, "bbb", 1),
                new Patient(6, "Egorka", "Kravch", 30, "bbb", 1)
            };
            var expected = new List<Patient>
            {
                new Patient(2, "Egorka", "Kravch", 21, "bbb", 1),
                new Patient(4, "Egorka", "Kravch", 20, "bbb", 1),
                new Patient(5, "Egorka", "Kravch", 100, "bbb", 1),
                new Patient(6, "Egorka", "Kravch", 30, "bbb", 1)
            };

            // Arrange

            var mock = new Mock<IPatientRepository>();
            var mock1 = new Mock<IPublishEndpoint>();

            mock.Setup(repo => repo.GetPatientsOlderThan18().Result).Returns(patients);
            var service = new PatientService(mock.Object, mock1.Object);

            // Act

            var actual = service.GetPatientsOlderThan();

            // Assert

            Assert.Equal(expected, actual.Result);
        }
        public List<Patient> Expected()
        {
            var expected = new List<Patient>
            {
                new Patient(2, "Egorka", "Kravch", 21, "bbb", 1),
                new Patient(4, "Egorka", "Kravch", 20, "bbb", 1),
                new Patient(5, "Egorka", "Kravch", 100, "bbb", 1),
                new Patient(6, "Egorka", "Kravch", 30, "bbb", 1)
            };
            return expected;
        }

        public List<Patient> Actual()
        {
            var actual = new List<Patient>
            {
                new Patient(1, "Egorka", "Kravch", 16, "bbb", 1),
                new Patient(2, "Egorka", "Kravch", 21, "bbb", 1),
                new Patient(3, "Egorka", "Kravch", 15, "bbb", 1),
                new Patient(4, "Egorka", "Kravch", 20, "bbb", 1),
                new Patient(5, "Egorka", "Kravch", 100, "bbb", 1),
                new Patient(6, "Egorka", "Kravch", 30, "bbb", 1)
            };
            return actual;
        }
    }
}