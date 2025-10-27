using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientSummaryApi.Data.Interfaces;
using PatientSummaryApi.Models;

namespace PatientSummaryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;

        public PatientsController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository; 
        }

        [HttpGet("{id}")]
        public IActionResult GetPatientSummary(int id) { 
            var patient = _patientRepository.GetPatientById(id);

            if(patient == null)
                return NotFound(new { Message = $"Patient not found with ID {id}" });

            return Ok(patient);
        }

        [HttpGet]
        public IActionResult GetAllPatients()
        {
            var patients = _patientRepository.GetAllPatients();

            if (patients == null)
                return NotFound(new { Message = $"No records found" });

            return Ok(patients);
        }


    }
}
