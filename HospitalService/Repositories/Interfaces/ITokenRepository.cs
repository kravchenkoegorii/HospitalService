using HospitalService.Models;

namespace HospitalService.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(Admin admin);
    }
}
