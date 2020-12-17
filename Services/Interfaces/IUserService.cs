using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IUserService
    {
        void Add(User user);
        bool Login(string email, string password);
        void Remove(User user);
        void Modify(User user);
        IList<User> GetAll();
        User GetByName(string name);
    }
}
