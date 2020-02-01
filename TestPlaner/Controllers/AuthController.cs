using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TestPlaner.Data;
using TestPlaner.Dtos;
using TestPlaner.models;

namespace TestPlaner.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserForRegsiterDto userForRegisterDto)
        {
            //validation
            if (!ModelState.IsValid)
            { 
                return BadRequest(ModelState);
            }
            userForRegisterDto.UserName = userForRegisterDto.UserName.ToLower();
            if (await _repo.UserExists(userForRegisterDto.UserName))
            {
                return BadRequest("Username is already taken ");
            }
            var newUser = new User
            {
                Username = userForRegisterDto.UserName
            };
            var creatUser = await _repo.Register(newUser, userForRegisterDto.Password);
            return StatusCode(201);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]UserForLoginDto userForRegisterDto)
        {
            var userRepo = await _repo.Login(userForRegisterDto.UserName, userForRegisterDto.Password);
            if (userRepo == null)
                return Unauthorized();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("you never guess this you mother fucker hacker =>()```136");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userRepo.Id.ToString()),
                    new Claim(ClaimTypes.Name, userRepo.Username)
                }),
                Expires = DateTime.Now.AddHours(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

           // var user = _mapper.Map<UserForListDto>(userFromRepo);

            return Ok(new { tokenString });
        }

    }

}