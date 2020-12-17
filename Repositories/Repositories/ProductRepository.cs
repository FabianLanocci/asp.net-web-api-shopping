using Models;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;

namespace Repositories.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private static ProductRepository instance = null; 
        private IConnection connection = new Connection();

        public IProductRepository GetInstance() 
        {
            if (instance == null)
                instance = new ProductRepository();

            return instance; 
        }

        public Boolean Add(Product product)
        {
            try
            {
                var insertCommand = connection.CreateCommand();
                insertCommand.CommandText = "INSERT INTO Products (CategoryId, Name, Description, Price, Image_URL) VALUES (@CategoryId, @Name, @Description, @Price, @Image_URL)";


                var CategoryIdParam = insertCommand.CreateParameter();
                CategoryIdParam.ParameterName = "CategoryId";
                CategoryIdParam.DbType = DbType.Int32;
                CategoryIdParam.Value = product.CategoryId;
                insertCommand.Parameters.Add(CategoryIdParam);

                var NameParam = insertCommand.CreateParameter();
                NameParam.ParameterName = "Name";
                NameParam.DbType = DbType.String;
                NameParam.Value = product.Name;
                NameParam.Size = 72;
                insertCommand.Parameters.Add(NameParam);

                var DescriptionParam = insertCommand.CreateParameter();
                DescriptionParam.ParameterName = "Description";
                DescriptionParam.DbType = DbType.String;
                DescriptionParam.Value = product.Description;
                DescriptionParam.Size = 255;
                insertCommand.Parameters.Add(DescriptionParam);

                var PriceParam = insertCommand.CreateParameter();
                PriceParam.ParameterName = "Price";
                PriceParam.DbType = DbType.Double;
                PriceParam.Value = product.Price;
                insertCommand.Parameters.Add(PriceParam);

                var Image_URLParam = insertCommand.CreateParameter();
                Image_URLParam.ParameterName = "Image_URL";
                Image_URLParam.DbType = DbType.String;
                Image_URLParam.Value = product.Image_Url;
                Image_URLParam.Size = 100;
                insertCommand.Parameters.Add(Image_URLParam);

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
            }
            finally
            {
                connection.Close();
            }
        }

        public IList<Product> GetAll()
        {
            IList<Product> productList = new List<Product>();
            try
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT ProductId, CategoryId, Name, Description, Price, Image_URL FROM Products";

                connection.Open();

                command.Prepare();

                var dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    var product = new Product();

                    product.ProductId = dataReader.GetInt32(0);
                    product.CategoryId = dataReader.GetInt32(1);
                    product.Name = dataReader.GetString(2);
                    product.Description = dataReader.GetString(3);
                    product.Price = dataReader.GetDouble(4);
                    product.Image_Url = dataReader.GetString(5);


                    productList.Add(product);
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

            return productList;
        }

        public Product GetById(int id)
        {
            Product product = new Product();
            try
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT ProductId, CategoryId, Name, Description, Price, Image_URL FROM Products WHERE ProductId = @ProductId";

                var IdParam = command.CreateParameter();
                IdParam.ParameterName = "ProductId";
                IdParam.DbType = DbType.Int32;
                IdParam.Value = id;
                command.Parameters.Add(IdParam);

                connection.Open();

                command.Prepare();

                var dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    product.ProductId = dataReader.GetInt32(0);
                    product.CategoryId = dataReader.GetInt32(1);
                    product.Name = dataReader.GetString(2);
                    product.Description = dataReader.GetString(3);
                    product.Price = dataReader.GetDouble(4);
                    product.Image_Url = dataReader.GetString(5);
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

            return product;
        }

        public Product GetByName(string name)
        {
            Product product = new Product();
            try
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT ProductId, CategoryId, Name, Description, Price, Image_URL FROM Products WHERE Name = @Name";

                var NameParam = command.CreateParameter();
                NameParam.ParameterName = "Name";
                NameParam.DbType = DbType.String;
                NameParam.Value = name;
                NameParam.Size = 72;
                command.Parameters.Add(NameParam);

                connection.Open();

                command.Prepare();

                var dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    product.ProductId = dataReader.GetInt32(0);
                    product.CategoryId = dataReader.GetInt32(1);
                    product.Name = dataReader.GetString(2);
                    product.Description = dataReader.GetString(3);
                    product.Price = dataReader.GetDouble(4);
                    product.Image_Url = dataReader.GetString(5);
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

            return product;

            /*return products
                .Where(x => x.Name == name)
                .FirstOrDefault();
            No tengo ProductIdea de donde viene esto. Una forma mas sencilla de hacerlo? Por las dudas lo hice de la antigua forma
            */
        }

        public void Modify(Product product)
        {
            try
            {
                var command = connection.CreateCommand();
                command.CommandText = "UPDATE Productos SET CategoryId = @CategoryId, Name = @Name, Description = @Description, Price = @Price, Image_URL=@Image_URL WHERE ProductId = @ProductId";

                var ProductIdParam = command.CreateParameter();
                ProductIdParam.ParameterName = "ProductId";
                ProductIdParam.DbType = DbType.Int32;
                ProductIdParam.Value = product.ProductId;
                command.Parameters.Add(ProductIdParam);

                var CategoryIdParam = command.CreateParameter();
                CategoryIdParam.ParameterName = "CategoryId";
                CategoryIdParam.DbType = DbType.Int32;
                CategoryIdParam.Value = product.CategoryId;
                command.Parameters.Add(CategoryIdParam);

                var NameParam = command.CreateParameter();
                NameParam.ParameterName = "Name";
                NameParam.DbType = DbType.String;
                NameParam.Value = product.Name;
                NameParam.Size = 72;
                command.Parameters.Add(NameParam);

                var DescriptionParam = command.CreateParameter();
                DescriptionParam.ParameterName = "Description";
                DescriptionParam.DbType = DbType.String;
                DescriptionParam.Value = product.Description;
                DescriptionParam.Size = 255;
                command.Parameters.Add(DescriptionParam);

                var PriceParam = command.CreateParameter();
                PriceParam.ParameterName = "Price";
                PriceParam.DbType = DbType.Double;
                PriceParam.Value = product.Price;
                command.Parameters.Add(PriceParam);

                var Image_URLParam = command.CreateParameter();
                Image_URLParam.ParameterName = "Image_URL"; 
                Image_URLParam.DbType = DbType.String;
                Image_URLParam.Value = product.Image_Url;
                Image_URLParam.Size = 100;
                command.Parameters.Add(Image_URLParam);

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

        public void Remove(Product product)
        { 
            try
            {

                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Products WHERE ProductId = @ProductId";

                var ProductIdParam = command.CreateParameter();
                ProductIdParam.ParameterName = "ProductId";
                ProductIdParam.Value = product.ProductId;
                ProductIdParam.DbType = DbType.Int32;
                command.Parameters.Add(ProductIdParam);

                connection.Open();

                command.Prepare();
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }finally
            {
                connection.Close();
            }

            


        }
    }
}
