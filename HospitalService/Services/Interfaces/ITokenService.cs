using HospitalService.Models;

namespace HospitalService.Services.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(Admin admin);
    }
}
