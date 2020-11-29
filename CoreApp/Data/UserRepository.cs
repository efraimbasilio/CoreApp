using CoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

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
               ConvertToEncrypt(user.Password,user.Username),
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
        public User GetUnhassedPassword([FromBody] User user)
        {
            var pass = ConvertToEncrypt(user.Password,user.Username);

            user = _context.Users.Where(u => u.Username == user.Username && u.Password == pass).FirstOrDefault();
            return user; 

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

       
        public static string Key = "sdasd@@@dsasd@";

        public static string ConvertToEncrypt(string password,string username)
        {
            if (string.IsNullOrEmpty(password)) return "";

            password += username;
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(passwordBytes);
        }

        public static string ConvertToDecrypt(string base64EncodeData, string username)
        {
            if (string.IsNullOrEmpty(base64EncodeData)) return "";

            var base64EncodeBytes = Convert.FromBase64String(base64EncodeData);
            var result = Encoding.UTF8.GetString(base64EncodeBytes);
            result = result.Substring(0, result.Length - username.Length);
            return result;
        }

       
    }
}
