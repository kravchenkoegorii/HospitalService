using HospitalService.Interfaces;
using HospitalService.Models;
using HospitalService.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalService.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<Admin> DeleteAdmin(int id)
        {
            return await _adminRepository.DeleteAdmin(id);
        }

        public async Task<Admin> GetAdmin(int id)
        {
            return await _adminRepository.GetAdmin(id);
        }

        public async Task<List<Admin>> GetAdmins()
        {
            return await _adminRepository.GetAdmins();
        }
    }
}
