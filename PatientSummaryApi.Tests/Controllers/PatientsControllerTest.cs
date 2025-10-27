using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PatientSummaryApi.Controllers;
using PatientSummaryApi.Data.Interfaces;
using PatientSummaryApi.Models;

namespace PatientSummaryApi.Tests.Controllers
{
    public class PatientsControllerTest
    {
        [Fact]
        public void GetPatientSummary_Ok_WhenPatientExists()
        {
            var mockRepo = new Mock<IPatientRepository>();
            var expectedPatient = new Patient { Id = 1, NHSNumber = "AS5352343TY25", Name = "Adam Smith", DateOfBirth = new DateTime(1999, 5, 12), GPPractice = "Northumbria Healthcare clinic" };
            mockRepo.Setup(repo => repo.GetPatientById(1)).Returns(expectedPatient);
            var controller = new PatientsController(mockRepo.Object);

            var result = controller.GetPatientSummary(1);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var patient = Assert.IsType<Patient>(okResult.Value);
            Assert.Equal(expectedPatient.Id, patient.Id);
            Assert.Equal(expectedPatient.Name, patient.Name);

        }

        [Fact]
        public void GetPatientSummary_NotFound_WhenPatientExists()
        {
            var mockRepo = new Mock<IPatientRepository>();
            mockRepo.Setup(repo => repo.GetPatientById(It.IsAny<int>())).Returns((Patient?)null);
            var controller = new PatientsController(mockRepo.Object);

            var result = controller.GetPatientSummary(10);

            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Contains("Patient not found", notFoundResult.Value!.ToString()!, StringComparison.OrdinalIgnoreCase);
        }
    }
}
