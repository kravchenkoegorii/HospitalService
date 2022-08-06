using HospitalService.Data;
using HospitalService.DTOs;
using HospitalService.Exceptions;
using HospitalService.Models;
using HospitalService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HospitalService.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly HospitalDbContext _dbContext;
        private readonly ITokenService _tokenService;

        public AuthorizationService(HospitalDbContext dbContext, ITokenService tokenService)
        {
            _dbContext = dbContext;
            _tokenService = tokenService;
        }

        public async Task<ActionResult<AdminDto>> Login(LoginDto loginDto)
        {
            var admin = await _dbContext.Admins
                .SingleOrDefaultAsync(a => a.UserName == loginDto.Username.ToLower());

            if (admin == null)
                throw new UnauthorizedException("Invalid Username!");

            using var hmac = new HMACSHA512(admin.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != admin.PasswordHash[i])
                    throw new UnauthorizedException("Invalid Password!");
            }

            return new AdminDto
            {
                Username = admin.UserName,
                Token = _tokenService.CreateToken(admin)
            };
        }

        public async Task<AdminDto> Register(RegisterDto registerDto)
        {
            using var hmac = new HMACSHA512();

            var admin = new Admin
            {
                UserName = registerDto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            _dbContext.Admins.Add(admin);
            await _dbContext.SaveChangesAsync();

            return new AdminDto
            {
                Username = admin.UserName,
                Token = _tokenService.CreateToken(admin)
            };
        }


        public async Task<bool> AdminExists(string username)
        {
            return await _dbContext.Admins.AnyAsync(x => x.UserName == username.ToLower());
        }
    }
}
