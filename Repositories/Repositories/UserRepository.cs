using Models;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;

namespace Repositories.Repositories
{
    public class UserRepository : IUserRepository
    { 
        private static UserRepository instance = null;
        private IConnection connection = new Connection();

        public IUserRepository GetInstance()
        {
            if (instance == null)
                instance = new UserRepository();

            return instance;
        }

        public void Add(User user)
        {
            try
            {
                var insertCommand = connection.CreateCommand();
                insertCommand.CommandText = "INSERT INTO Users(TypeId, Name, Email, Password) VALUES (@TypeId, @Name, @Email, @Password)";


                var TypeIdParam = insertCommand.CreateParameter();
                TypeIdParam.ParameterName = "TypeId";
                TypeIdParam.Value = user.TypeId;
                TypeIdParam.DbType = DbType.Int32;
                insertCommand.Parameters.Add(TypeIdParam);

                var NameParam = insertCommand.CreateParameter();
                NameParam.ParameterName = "Name";
                NameParam.Value = user.Name;
                NameParam.DbType = DbType.String;
                NameParam.Size = 72;
                insertCommand.Parameters.Add(NameParam);

                var EmailParam = insertCommand.CreateParameter();
                EmailParam.ParameterName = "Email";
                EmailParam.Value = user.Email;
                EmailParam.DbType = DbType.String;
                EmailParam.Size = 72;
                insertCommand.Parameters.Add(EmailParam);

                var PasswordParam = insertCommand.CreateParameter();
                PasswordParam.ParameterName = "Password";
                PasswordParam.Value = user.Password;
                PasswordParam.DbType = DbType.String;
                PasswordParam.Size = 32;
                insertCommand.Parameters.Add(PasswordParam);

                connection.Open();

                insertCommand.Prepare();
                insertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

        }

        public bool Login(string email, string password)
        {
            bool succesful = false;
            try
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT Email, Password FROM Users WHERE Email = @Email AND Password = @Password";

                var EmailParam = command.CreateParameter();
                EmailParam.ParameterName = "Email";
                EmailParam.Value = email;
                EmailParam.DbType = DbType.String;
                EmailParam.Size = 72;
                command.Parameters.Add(EmailParam);

                var PasswordParam = command.CreateParameter();
                PasswordParam.ParameterName = "Password";
                PasswordParam.Value = password;
                PasswordParam.DbType = DbType.String;
                PasswordParam.Size = 32;
                command.Parameters.Add(PasswordParam);

                connection.Open();

                command.Prepare();

                var dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    if(dataReader.GetString(0) == email && dataReader.GetString(1) == password)
                    {
                        succesful = true;
                    }
                }

                dataReader.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return succesful;  
        }

        public IList<User> GetAll()
        {

            IList<User> users = new List<User>();
            try
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT UserId, TypeId, Name, Email, Password FROM Users";

                connection.Open();

                command.Prepare();

                var dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    var user = new User();

                    user.UserId = dataReader.GetInt32(0);
                    user.TypeId = dataReader.GetInt32(1);
                    user.Name = dataReader.GetString(2);
                    user.Email = dataReader.GetString(3);
                    user.Password = dataReader.GetString(4);

                    users.Add(user);
                }

                dataReader.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }finally
            {
                connection.Close();
            }

            return users;
        }

        public User GetByName(string name)
        {
            //No contempla que haya varios users con el mismo nombre

            User user = new User();
            try
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT UserId, TypeId, Name, Email, Password FROM Users WHERE Name = @Name";

                var NameParam = command.CreateParameter();
                NameParam.ParameterName = "Name";
                NameParam.Value = name;
                NameParam.DbType = DbType.String;
                NameParam.Size = 72;
                command.Parameters.Add(NameParam);

                connection.Open();

                command.Prepare();

                var dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {

                    user.UserId = dataReader.GetInt32(0);
                    user.TypeId = dataReader.GetInt32(1);
                    user.Name = dataReader.GetString(2);
                    user.Email = dataReader.GetString(3);
                    user.Password = dataReader.GetString(4);
                }

                dataReader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return user;
        }

        public void Modify(User user)
        {
            try
            {
                var command = connection.CreateCommand();
                command.CommandText = "UPDATE Users SET TypeId = @TypeId, Name = @Name, Email = @Email, Password = @Password WHERE UserId = @UserId";

                var UserIdParam = command.CreateParameter();
                UserIdParam.ParameterName = "UserId";
                UserIdParam.Value = user.UserId;
                UserIdParam.DbType = DbType.Int32;
                command.Parameters.Add(UserIdParam);

                var TypeIdParam = command.CreateParameter();
                TypeIdParam.ParameterName = "TypeId";
                TypeIdParam.Value = user.TypeId;
                TypeIdParam.DbType = DbType.Int32;
                command.Parameters.Add(TypeIdParam);

                var NameParam = command.CreateParameter();
                NameParam.ParameterName = "Name";
                NameParam.Value = user.Name;
                NameParam.DbType = DbType.String;
                NameParam.Size = 72;
                command.Parameters.Add(NameParam);

                var EmailParam = command.CreateParameter();
                EmailParam.ParameterName = "Email";
                EmailParam.Value = user.Email;
                EmailParam.DbType = DbType.String;
                EmailParam.Size = 72;
                command.Parameters.Add(EmailParam);

                var PasswordParam = command.CreateParameter();
                PasswordParam.ParameterName = "Password";
                PasswordParam.Value = user.Password;
                PasswordParam.DbType = DbType.String;
                PasswordParam.Size = 32;
                command.Parameters.Add(PasswordParam);

                connection.Open();

                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public void Remove(User user)
        {
            try
            {
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Users WHERE UserId = @UserId";

                var UserIdParam = command.CreateParameter();
                UserIdParam.ParameterName = "UserId";
                UserIdParam.Value = user.UserId;
                UserIdParam.DbType = DbType.String;
                command.Parameters.Add(UserIdParam);

                connection.Open();

                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
