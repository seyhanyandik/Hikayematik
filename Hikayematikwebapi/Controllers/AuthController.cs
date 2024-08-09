using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Hikayematikwebapi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        string SigningKey = "BuBenimCokGucluVeUzunSigninKey1234567890";
        [HttpGet]
        public IActionResult Get(string userName, string password)
        {

            // Kullanıcıya özgü claims oluşturuluyor
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(JwtRegisteredClaimNames.Email, userName),
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SigningKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: "https://localhost:7113/", // 'appsettings.json'da tanımlı issuer ile eşleşmeli
                audience: "BuBenimKullandigimAudienceDegeri", // 'appsettings.json'da tanımlı audience ile eşleşmeli
                claims: claims,
                expires: DateTime.Now.AddDays(15),
                notBefore: DateTime.Now,
                signingCredentials: credentials
            );

            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return Ok(token);
        }
        [HttpGet("Validatetoken")]

        public bool Validatetoken(string token)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SigningKey));
            try
            {
                JwtSecurityTokenHandler handler = new();
                handler.ValidateToken(token, new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = securityKey,
                    ValidateLifetime = true,
                    ValidateAudience = true,
                    ValidateIssuer = true
                }, out SecurityToken validatedToken) ;
                var jwtToken = (JwtSecurityToken)validatedToken;
                var claims = jwtToken.Claims.ToList();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}