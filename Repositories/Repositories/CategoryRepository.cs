using Models;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;

namespace Repositories.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private static CategoryRepository instance = null;
        private IConnection connection = new Connection();

        public ICategoryRepository GetInstance()
        {
            if (instance == null)
                instance = new CategoryRepository();

            return instance;
        }


        public Boolean Add(Category category)
        {
            try
            {
                var insertCommand = connection.CreateCommand();
                insertCommand.CommandText = "INSERT INTO Categories (Name)  VALUES (@Name)";

                var NameParam = insertCommand.CreateParameter();
                NameParam.ParameterName = "Name";
                NameParam.DbType = DbType.String;
                NameParam.Value = category.Name;
                NameParam.Size = 72;
                insertCommand.Parameters.Add(NameParam);

                connection.Open();

                insertCommand.Prepare();
                insertCommand.ExecuteNonQuery();

                Boolean succesful = false;
                var affedtedRows = insertCommand.ExecuteNonQuery();
                if (affedtedRows >= 1) succesful = true;

                return succesful;
            }
            catch (Exception ex)
            {
                throw ex;
            }finally
            {
                connection.Close();
            }
        }

        public IList<Category> GetAll()
        {
            IList<Category> categories = new List<Category>();

            try
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT CategoryId, Name FROM Categories";

                connection.Open();

                command.Prepare();
                var dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    var category = new Category();
                    category.CategoryId = dataReader.GetInt32(0);
                    category.Name = dataReader.GetString(1);

                    categories.Add(category);
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

            return categories;
        }

        public Category GetByName(string name)
        {
            Category category = new Category();

            try
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT CategoryId, Name FROM Categories WHERE Name = @Name";

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
                    category.CategoryId = dataReader.GetInt32(0);
                    category.Name = dataReader.GetString(1);
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

            return category;
        }

        public void Modify(Category category)
        {
            try
            {
                var command = connection.CreateCommand();
                command.CommandText = "UPDATE Categories SET Name = @Name WHERE CategoryId = @CategoryId";

                var NameParam = command.CreateParameter();
                NameParam.ParameterName = "Name";
                NameParam.Value = category.Name;
                NameParam.DbType = DbType.String;
                NameParam.Size = 72;
                command.Parameters.Add(NameParam);

                var CategoryIdParam = command.CreateParameter();
                CategoryIdParam.ParameterName = "CategoryId";
                CategoryIdParam.Value = category.CategoryId;
                CategoryIdParam.DbType = DbType.Int32;
                command.Parameters.Add(CategoryIdParam);

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

        public void Remove(Category category)
        {
            try
            {
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Categories WHERE CategoryId = @CategoryId";

                var CategoryIdParam = command.CreateParameter();
                CategoryIdParam.ParameterName = "CategoryId";
                CategoryIdParam.Value = category.CategoryId;
                CategoryIdParam.DbType = DbType.Int32;
                command.Parameters.Add(CategoryIdParam);

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
