using Identity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.IServices
{
    public interface IGenerateJWTService
    {
        string GenerateJWT(User user);
    }
}
