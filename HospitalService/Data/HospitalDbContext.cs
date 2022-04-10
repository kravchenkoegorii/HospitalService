using HospitalService.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalService.Data;

public class HospitalDbContext:DbContext
{
    Doctor doctor = new Doctor
    {
        Id = 1, FirstName = "Egor", LastName = "Kravchenko", Age = 18, Specialization = "Pediatrist"
    };
}