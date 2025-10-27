using PatientSummaryApi.Models;

namespace PatientSummaryApi.Data.Interfaces
{
    public interface IPatientRepository
    {
        public Patient? GetPatientById(int Id);

        public IEnumerable<Patient> GetAllPatients();
    }
}
