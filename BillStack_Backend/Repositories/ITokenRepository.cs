using Microsoft.AspNetCore.Identity;

namespace BillStack_Backend.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
