using HospitalService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalService.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(Admin admin);
    }
}
