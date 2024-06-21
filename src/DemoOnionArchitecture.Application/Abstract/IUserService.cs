using DemoOnionArchitecture.Application.DTOs.Request;
using DemoOnionArchitecture.Application.DTOs.Response;
using DemoOnionArchitecture.Domain.Entity;

namespace DemoOnionArchitecture.Application.Abstract {
    public interface IUserService
    {
        Task<User> GetUserByEmail(string email);
        Task<LoginResponseVM> Login(LoginRequestVM model);
        Task<User> Register(RegisterRequestVM model);
    }

}


