using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CoiffeurApp.Models
{
    public class SingleConnection
    {
        public SingleConnection()
        {

        }
        private static SingleConnection _connectionString = null;
        private string _string = null;
        public static string ConString
        {
            get
            {
                if (_connectionString == null)
                {
                    _connectionString = new SingleConnection { _string = SingleConnection.Connect() };
                    return _connectionString._string;
                }
                else
                    return _connectionString._string;
            }
        }

        private static string Connect()
        {


            SqlConnectionStringBuilder sqlString = new SqlConnectionStringBuilder
            {
                DataSource = "DESKTOP-GK8RQIK\\SQLEXPRESS",
                InitialCatalog = "CoiffeurDatabase",
                UserID = "sa",
                Password = "sa12345"
            };
            return sqlString.ConnectionString;
        }
    }
}