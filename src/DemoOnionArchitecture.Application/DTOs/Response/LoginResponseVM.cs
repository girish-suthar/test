
using DemoOnionArchitecture.Domain.Entity;

namespace DemoOnionArchitecture.Application.DTOs.Response
{
    public class LoginResponseVM
    {
        public User Users { get; set; }
        public string Token { get; set; }
    }
}
