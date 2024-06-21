

using DemoOnionArchitecture.Application.Abstract;
using DemoOnionArchitecture.Application.DTOs.Request;
using DemoOnionArchitecture.Application.DTOs.Response;
using DemoOnionArchitecture.DataAccess.Configurations;
using DemoOnionArchitecture.DataAccess.Context;
using DemoOnionArchitecture.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Services.Implentations
{
    public class UserService : IUserService
    {
        private readonly ApplicationdbContext _context;

        public UserService(ApplicationdbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<LoginResponseVM> Login(LoginRequestVM model)
        {
            User user = await GetUserByEmail(model.Email);
            LoginResponseVM ResponseModel = new LoginResponseVM();
            if (user == null)
            {
                ResponseModel.Users = null;
                ResponseModel.Token = "";
            }
            else
            {
                if (user.PasswordHash != model.Password)
                {
                    ResponseModel.Users = null;
                    ResponseModel.Token = "";
                }
                else
                {
                    string Rawkey = JwtConfiguration.JWT_KEY;
                    var tokenhandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(Rawkey);
                    var descriptor = new SecurityTokenDescriptor
                    {
                        Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]{
                            new Claim(ClaimTypes.Name,user.UserId.ToString()),
                            new Claim(ClaimTypes.Role,user.Role.ToString())
                        }),
                        Expires= DateTime.UtcNow.AddDays(7),
                        SigningCredentials =  new(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature),
                    };
                    var token = tokenhandler.CreateToken(descriptor);
                    ResponseModel.Users = user;
                    ResponseModel.Token = tokenhandler.WriteToken(token);
                }
            }
            return ResponseModel;

        }
        public async Task<User> Register(RegisterRequestVM model)
        {
            User user = await GetUserByEmail(model.Email);
            if (user != null)
            {
                return null;
            }
            user = new();
            user.Email = model.Email;
            user.PasswordHash = model.Password;
            user.UserName = model.UserName;
            user.Role = model.Role;

            _context.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
