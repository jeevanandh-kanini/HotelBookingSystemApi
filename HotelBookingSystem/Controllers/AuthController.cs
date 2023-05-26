using Flight_Booking.Models;
using HotelBookingSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HotelBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly ApplicationDbContext uDbC;
        public AuthController(ApplicationDbContext udb, IConfiguration ic)
        {
            this.uDbC = udb;
            this.configuration = ic;

        }
        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterUser ud)
        {

            var user = new RegisterUser()
            {
                UserName = ud.UserName,
                Password = ud.Password,
                Email = ud.Email,
                Role = ud.Role,

            };
            uDbC.Add(user);
            uDbC.SaveChanges();
            return Ok(user);


        }
        [HttpPost("Login")]
        public async Task<ActionResult> SignIn(LoginUser ud)
        {
            string uname = ud.UserName;
            string pass = ud.Password;
            var user = uDbC.RegisterUser.FirstOrDefault(x => x.UserName == uname);
            if (user != null && user.Password == ud.Password)
            {
                var token = CreatToken(user);
                return Ok(new { token, user });
            }
            else
            {
                return BadRequest("user not found");
            }
        }

        private string CreatToken(RegisterUser ud)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, ud.UserName),
                new Claim(ClaimTypes.Role,ud.Role)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("AppSetting:Token").Value!));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;



        }
    }
}
