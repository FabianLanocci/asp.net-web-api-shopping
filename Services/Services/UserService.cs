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
    public class UserService : IUserService
    {
        IUserRepository users = new UserRepository();

        public void Add(User user)
        {
            try
            {
                if(users.GetAll().Where(x => x.UserId == user.UserId).FirstOrDefault() == null)
                {
                     if(user != null)
                    {
                        users.Add(user);
                    }
                }
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Login(string email, string password)
        {
            bool succesful = false;
            try
            {
                if ((users.GetAll().Where(x => x.Email == email).FirstOrDefault() != null) && (users.GetAll().Where(x => x.Password == password).FirstOrDefault() != null))
                {
                    succesful = users.Login(email, password);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return succesful;
        }

        public IList<User> GetAll()
        {
            try
            {
                return users.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public User GetByName(string name)
        {
            User user = null;
            
            try
            {
                if (users.GetAll().Where(x => x.Name == name).FirstOrDefault() != null)
                {
                    user = users.GetByName(name);              
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return user;
        }

        public void Modify(User user)
        {
            try
            {
                if (users.GetAll().Where(x => x.UserId == user.UserId).FirstOrDefault() != null)
                {
                    if(user != null){
                        users.Modify(user);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Remove(User user)
        {
            try
            {
                if (users.GetAll().Where(x => x.UserId == user.UserId).FirstOrDefault() != null)
                {
                    if (user != null)
                    {
                        users.Remove(user);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
