using Microsoft.Extensions.Configuration;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace Repositories.Repositories
{
     public class Connection : IConnection
    {
        //Conexión a SQL Server
        //private SqlConnection connection = new SqlConnection(@"Server=XHYLONUS\SQLEXPRESS; Database=Carrito; Trusted_Connection=True;");

        //Conexion para la API ==============
        SqlConnection connection = null; 
         
        public Connection(IConfiguration config )
        {
            string connectionString = config.GetConnectionString("AppDbConnectionString");

            connection = new SqlConnection(connectionString);
        } 
         
        public Connection()
        {
            
            connection = new SqlConnection(@"Server = XHYLONUS\SQLEXPRESS; Database = Carrito; Trusted_Connection=True;");
        }

        public void Close()
        {
            try
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IDbCommand CreateCommand()
        {
            try
            {
                var command = connection.CreateCommand();
                command.Connection = connection;

                return command;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Open()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
