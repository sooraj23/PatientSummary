using PatientSummaryApi.Data.Interfaces;
using PatientSummaryApi.Models;

namespace PatientSummaryApi.Data
{
    public class PatientRepository : IPatientRepository
    {
        private readonly List<Patient> patients = new() { 
            new Patient { Id = 1, NHSNumber = "AS5352343TY25", Name = "Adam Smith", DateOfBirth = new DateTime(1999, 5, 12), GPPractice = "Northumbria Healthcare clinic" },
            new Patient { Id = 2, NHSNumber = "JC6547892CT25", Name = "John Cockram", DateOfBirth = new DateTime(1989, 9, 7), GPPractice = "The City Road Medical Centre" },
            new Patient { Id = 3, NHSNumber = "SJ4561289PH25", Name = "Simon Jenkins", DateOfBirth = new DateTime(1970, 4, 25), GPPractice = "Northumbria Healthcare clinic" },
            new Patient { Id = 4, NHSNumber = "LB7982564LD25", Name = "Liam Bibby", DateOfBirth = new DateTime(1985, 7, 16), GPPractice = "St Mary’s Surgery" },
            new Patient { Id = 5, NHSNumber = "AC7456321OT25", Name = "Alastair Campell", DateOfBirth = new DateTime(1979, 4, 1), GPPractice = "The Maples Medical Centre" }
        };
        public Patient? GetPatientById(int Id)
        {
            return patients.FirstOrDefault(p => p.Id == Id);
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            return patients;
        }
    }
}
