using back.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using back.Utils;

namespace back.TokenConfiguration
{
    public class JwtService
    {

        public JwtService()
        {
           
        }
        public String GeneratedToken(User user)
        {
            AcessKey KeyConfig = new AcessKey();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(KeyConfig.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]{
                        new Claim(ClaimTypes.Name,user.Username),
                        new Claim(ClaimTypes.Role,"Admin")
                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )

            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
            
        }

    }
    
}