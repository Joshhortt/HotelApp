using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HotelAppLibrary.Databases
{
    public class SqlDataAccess
    {
        private readonly IConfiguration _config;

        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

            public List<T> LoadData<T, U>(string sqlStatement, U parameters, string connectionStringName)
        {
            string connectionString = _config.GetConnectionString("");

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<T> rows = connection.Query<T>(sqlStatement, parameters).ToList();
                return rows;
            }
        }
    }
}

