using E_Commerce.Data.Entities.IdentityEntities;

namespace E_Commerce.Service.Services.TokenService
{
    public interface ITokenService
    {
        string GenerateToken(AppUser user);
    }
}
