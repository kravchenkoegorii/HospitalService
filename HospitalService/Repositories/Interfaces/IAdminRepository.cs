using HospitalService.Models;
using System.Collections.Generic;
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
