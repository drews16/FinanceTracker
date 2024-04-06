using System.Security.Claims;

namespace FiananceTracker.BLL.Services.Interfaces
{
    public interface ITokenService
    {
        string CreateJwtToken(IEnumerable<Claim> claims);
    }
}