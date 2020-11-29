using CoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Data
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();

        User GetById(int id);

        User Add(User user);

        void Delete(int id);

        User Update(User useChanges);

        

        User Login(User user);
    }
}
