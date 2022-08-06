using HospitalService.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HospitalService.Services.Interfaces
{
    public interface IAuthorizationService
    {
        Task<AdminDto> Register(RegisterDto registerDto);
        Task<ActionResult<AdminDto>> Login(LoginDto loginDto);
        Task<bool> AdminExists(string username);
    }
}
