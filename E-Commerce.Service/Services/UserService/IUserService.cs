using E_Commerce.Service.Services.UserService.Dtos;

namespace E_Commerce.Service.Services.UserService
{
    public interface IUserService
    {
        Task<UserDto> Login(LoginDto input);
        Task<UserDto> Register(RegisterDto input);
    }
}
