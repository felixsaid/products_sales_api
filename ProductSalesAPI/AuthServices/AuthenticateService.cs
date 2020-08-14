using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProductSalesAPI.Config;
using ProductSalesAPI.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProductSalesAPI.AuthServices
{
    public class AuthenticateService : IAuthenticateService
    {

        private readonly AppSettings _appSettings;

        private readonly ProductAPIDbContext _context;

        public AuthenticateService(IOptions<AppSettings> appSettings, ProductAPIDbContext context)
        {
            _appSettings = appSettings.Value;
            _context = context;
        }


        public AuthUser Authenticate(string userName, string password)
        {
            var user = _context.AuthUser.SingleOrDefault(x => x.UserName == userName && x.Password == password);

            //return null is user is not found
            if (user == null)
                return null;

            //if user is found
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserId.ToString()),
                    new Claim(ClaimTypes.Role, "Admin"),
                    new Claim(ClaimTypes.Version, "V3.1")
                }),

                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            user.Password = null;

            return user;
        }
    }
}
