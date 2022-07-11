using HospitalService.Data;
using HospitalService.Interfaces;
using HospitalService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalService.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly HospitalDbContext _dbContext;

        public AdminRepository(HospitalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Admin> DeleteAdmin(int id)
        {
            var admin = await _dbContext.Admins.FindAsync(id);
            if (admin == null)
            {
                throw new Exception("Admin not found!");
            }

            _dbContext.Admins.Remove(admin);
            await _dbContext.SaveChangesAsync();
            return admin;
        }

        public async Task<Admin> GetAdmin(int id)
        {
            return await _dbContext.Admins.FindAsync(id);
        }

        public async Task<List<Admin>> GetAdmins()
        {
            return await _dbContext.Admins.ToListAsync();
        }
    }
}
