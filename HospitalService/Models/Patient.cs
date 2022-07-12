namespace HospitalService.Models
{
    public class Patient
    {
        public Patient(int id, string firstName, string lastName, int age, string description, int doctorId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Description = description;
            DoctorId = doctorId;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }

        //Navigation props
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }


        public bool ValidateAge()
        {
            return Age >= 18;
        }
    }
}