using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CoreApp.Data;
using CoreApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;

namespace CoreApp.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UsersController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAll()
        {
            var users = _repository.GetAll();
            if (users != null)
            {
                return Ok(users);
            }

            return BadRequest("User not found");
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetById(int id)
        {
            var users = _repository.GetById(id);

            if (users != null)
            {
                return Ok(users);
            }

            return BadRequest("User not found");
        }

        [HttpPost]
        public ActionResult<User> Add(User user)
        {
            var users = _repository.Add(user);
            return Ok("Successfully Added a new user");
        }


        [HttpDelete("{id}")]
        public ActionResult<User> Delete(int id)
        {
            User user = _repository.GetById(id);

            if (user != null)
            {
                _repository.Delete(user.Id);
                return Ok("User Deleted successfully");
            }

            return BadRequest("User not found");
        }

        [HttpPut]
        public ActionResult<User> Update(User userChanges)
        {
            var userItems = _repository.Update(userChanges);

            return Ok("User: " + userItems.Username + " successfully updated.");
        }

        [HttpPost("Login")]
        public ActionResult<User> GetHashed(User user)
        {
            var users = _repository.Login(user);

            if (users != null)
            {                        
                var tokenStr = GenerateJWTToken(user);
                return Ok(new { token = tokenStr });
                
            }

            return BadRequest("User not found");

        }

        private string GenerateJWTToken(User use)
        {
            var claims = new[]
           {
                new Claim(JwtRegisteredClaimNames.Sub,use.Username),
                new Claim(JwtRegisteredClaimNames.Email,use.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var secretBytes = Encoding.UTF8.GetBytes(Constants.Secrets);
            var key = new SymmetricSecurityKey(secretBytes);
            var algorithm = SecurityAlgorithms.HmacSha256;
            var signingCredentials = new SigningCredentials(key, algorithm);

            var token = new JwtSecurityToken(
                Constants.Issuer,
                Constants.Audience,
                claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddHours(1),
                signingCredentials);

            var tokenJson = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenJson;
        }
    }
}
