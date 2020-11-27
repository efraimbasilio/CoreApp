using CoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDBContext _context;

        public UserRepository(AppDBContext context)
        {
            _context = context;
        }

        public User Add([FromBody]User user)
        {
            _context.Database.ExecuteSqlRaw("spUserInsert {0},{1},{2}",
                                user.Username,
                                user.Password,
                                user.Email);
            return user;
        }

        public void Delete(int id)
        {
            _context.Database.ExecuteSqlRaw("spUserDelete {0}", id);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users
                            .FromSqlRaw<User>("SELECT * FROM Users")
                            .ToList();
        }

        public User GetById(int id)
        {
            SqlParameter parameter = new SqlParameter("@Id", id);
            return _context.Users
                            .FromSqlRaw<User>("spUserGetById @Id", parameter)
                            .ToList()
                            .FirstOrDefault();
        }

        public User Update(User useChanges)
        {
            _context.Database.ExecuteSqlRaw("spUserUpdate {0},{1},{2},{3}",
                                    useChanges.Username,
                                    useChanges.Password,
                                    useChanges.Email,
                                    useChanges.Id);
            return useChanges;
        }
    }
}
