using HospitalService.Controllers.BaseController;
using HospitalService.Data;
using HospitalService.DTOs;
using HospitalService.Interfaces;
using HospitalService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HospitalService.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly HospitalDbContext _dbContext;
        private readonly ITokenService _tokenService;

        public AccountController(HospitalDbContext dbContext, ITokenService tokenService)
        {
            _dbContext = dbContext;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AdminDto>> Register(RegisterDto registerDto)
        {
            if (await AdminExists(registerDto.Username))
                return BadRequest("Username is taken!");

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

        [HttpPost("login")]
        public async Task<ActionResult<AdminDto>> Login(LoginDto loginDto)
        {
            var admin = await _dbContext.Admins
                .SingleOrDefaultAsync(a => a.UserName == loginDto.Username.ToLower());

            if (admin == null)
                return Unauthorized("Invalid username!");

            using var hmac = new HMACSHA512(admin.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for(int i = 0; i<computedHash.Length;i++)
            {
                if (computedHash[i] != admin.PasswordHash[i])
                    return Unauthorized("Invalid password!");
            }

            return new AdminDto
            {
                Username = admin.UserName,
                Token = _tokenService.CreateToken(admin)
            };
        }

        private async Task<bool> AdminExists(string username)
        {
            return await _dbContext.Admins.AnyAsync(x => x.UserName == username.ToLower());
        }
    }
}
