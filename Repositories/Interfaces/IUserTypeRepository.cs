using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Interfaces
{
    public interface IUserTypeRepository
    {
        void Add(UserType userType);
        void Modify(UserType userType);
        void Remove(UserType userType);
        IList<UserType> GetAll();
        UserType GetByName(string name);
        IUserTypeRepository GetInstance();
    }
}
