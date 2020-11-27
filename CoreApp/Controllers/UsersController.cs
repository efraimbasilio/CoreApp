using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApp.Data;
using CoreApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
