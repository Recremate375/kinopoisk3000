using Identity.Domain.Models;

namespace Identity.Application.IServices
{
    public interface IGenerateJWTService
    {
        string GenerateJWT(User user);
    }
}
