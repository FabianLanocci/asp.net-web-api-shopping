using Models;
using Repositories.Interfaces;
using Repositories.Repositories;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Services
{
    public class UserTypeService : IUserTypeService
    {
        IUserTypeRepository userTypes = new UserTypeRepository();

        public void Add(UserType userType)
        {
            try
            {
                if(userTypes.GetAll().Where(x => x.TypeId == userType.TypeId).FirstOrDefault() == null)
                {
                    if(userType != null)
                    {
                        userTypes.Add(userType);
                    }
                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public IList<UserType> GetAll()
        {
            try
            {
                return userTypes.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UserType GetByName(string name)
        {
            UserType userType = null;

            try
            {
                if (userTypes.GetAll().Where(x => x.Name == name).FirstOrDefault() != null)
                {
                    userType = userTypes.GetByName(name);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return userType;
        }

        public void Modify(UserType userType)
        {
            try
            {
                if (userTypes.GetAll().Where(x => x.TypeId == userType.TypeId).FirstOrDefault() != null)
                {
                    userTypes.Modify(userType);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Remove(UserType userType)
        {
            try
            {
                if (userTypes.GetAll().Where(x => x.TypeId == userType.TypeId).FirstOrDefault() != null)
                {
                    userTypes.Remove(userType);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
