using System.Collections.Generic;

namespace HospitalService.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Specialization { get; set; }
        
        //Navigation props
        public List<Patient> Patients { get; set; }
     }
} 