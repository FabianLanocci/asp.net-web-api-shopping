using Models;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;

namespace Repositories.Repositories
{
    public class UserTypeRepository : IUserTypeRepository
    {
        private static UserTypeRepository instance = null;
        private IConnection connection = new Connection();

        public IUserTypeRepository GetInstance()
        {
            if (instance == null)
                instance = new UserTypeRepository();

            return instance;
        }

        public void Add(UserType userType)
        {
            try
            {
                var insertCommand = connection.CreateCommand();
                insertCommand.CommandText = "INSERT INTO UserTypes (Name) VALUES (@Name)";


                var NameParam = insertCommand.CreateParameter();
                NameParam.ParameterName = "Name";
                NameParam.Value = userType.Name;
                NameParam.DbType = DbType.String;
                NameParam.Size = 72;
                insertCommand.Parameters.Add(NameParam);

                connection.Open();

                insertCommand.Prepare();
                insertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }finally
            {
                connection.Close();
            }

        }

        public IList<UserType> GetAll()
        {
            IList<UserType> userTypes = new List<UserType>();

            try
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT TypeId, Name FROM UserTypes";

                connection.Open();

                command.Prepare();
                var dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    var userType = new UserType();
                    userType.TypeId = dataReader.GetInt32(0);
                    userType.Name = dataReader.GetString(1);

                    userTypes.Add(userType);
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

            return userTypes;
        }

        public UserType GetByName(string name)
        {
            UserType userType = new UserType();

            try
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT TypeId, Name FROM UserTypes WHERE Name = @Name";

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
                    userType.TypeId = dataReader.GetInt32(0);
                    userType.Name = dataReader.GetString(1);
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

            return userType;
        }

        public void Modify(UserType userType)
        {
            try
            {
                var command = connection.CreateCommand();
                command.CommandText = "UPDATE UserTypes SET Name = @Name WHERE TypeId = @TypeId";

                var TypeIdParam = command.CreateParameter();
                TypeIdParam.ParameterName = "TypeId";
                TypeIdParam.Value = userType.TypeId;
                TypeIdParam.DbType = DbType.Int32;
                command.Parameters.Add(TypeIdParam);

                var NameParam = command.CreateParameter();
                NameParam.ParameterName = "Name";
                NameParam.Value = userType.Name;
                NameParam.DbType = DbType.String;
                NameParam.Size = 72;
                command.Parameters.Add(NameParam);

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

        public void Remove(UserType userType)
        {
            try
            {
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM UserTypes WHERE TypeId = @TypeId";

                var TypeIdParam = command.CreateParameter();
                TypeIdParam.ParameterName = "TypeId";
                TypeIdParam.Value = userType.TypeId;
                TypeIdParam.DbType = DbType.Int32;
                command.Parameters.Add(TypeIdParam);

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
