using HospitalService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalService.Interfaces
{
    public interface IAdminRepository
    {
        Task<Admin> DeleteAdmin(int id);

        Task<Admin> GetAdmin(int id);

        Task<List<Admin>> GetAdmins();
    }
}
