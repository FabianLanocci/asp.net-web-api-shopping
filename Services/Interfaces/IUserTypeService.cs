using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IUserTypeService
    {
        void Add(UserType userType);
        void Modify(UserType userType);
        void Remove(UserType userType);
        IList<UserType> GetAll();
        UserType GetByName(string name);
    }
}
