using System.Collections.Generic;

namespace HospitalService.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }

        //Navigation props
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}