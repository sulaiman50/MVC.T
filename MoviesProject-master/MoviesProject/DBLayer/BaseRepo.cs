using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MoviesProject.DBLayer
{
    public class BaseRepo
    {
        private readonly string connectionString;

        protected BaseRepo()
        {
            //connectionString = ConfigurationManager.ConnectionStrings["MoviesDB"].ConnectionString;
            connectionString = ConfigurationManager.ConnectionStrings["MoviesDBSameer"].ConnectionString;
        }

        protected SqlConnection GetConnection()
        {
            var Conection = new SqlConnection(connectionString);
            return Conection;
        }
        public void OpenConnection(SqlConnection connection)
        {
            connection.Open();

        }
    }
}
