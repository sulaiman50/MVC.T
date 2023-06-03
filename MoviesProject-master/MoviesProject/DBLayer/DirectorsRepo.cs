using MoviesProject.Constants;
using MoviesProject.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesProject.DBLayer
{
    public class DirectorsRepo : BaseRepo
    {
        public SqlCommand command(string query)
        {
            var connection = GetConnection();
            OpenConnection(connection);
            return new SqlCommand(query, connection);
        }

        public List<Director> ExcuteReader(string query, int? id = null)
        {
            var cmd = command(query);
            if (id != null)
            {
                cmd.Parameters.AddWithValue("@id", id);
                return ReadEntity(cmd.ExecuteReader(), id);
            }
            return ReadEntity(cmd.ExecuteReader());

        }

        // Read Director
        public List<Director> ReadEntity(SqlDataReader rdr, int? id = null)
        {
            var list = new List<Director>();

            while (rdr.Read())
            {
                var result = new Director();

                result.Id = Convert.ToInt32(rdr[0]);
                result.Name = rdr[1].ToString() != null ? rdr[1].ToString() : null;

                list.Add(result);
            }
            return list;
        }

        public int ExecuteNonQuery(string query, Director director, bool updated)
        {
            var cmd = command(query);
            if (updated == true)
            {
                var selectMovie = ExcuteReader(Queries.SelectDirectorByIdQuery, director.Id);
                if (selectMovie.Count() > 0)
                {
                    return UpdateEntity(cmd, director);
                }
            }
            else
            {
                return InsertEntity(cmd, director);
            }
            return 0;
        }

        #region update Director
        public int UpdateEntity(SqlCommand sqlCommand, Director director)
        {

            sqlCommand.Parameters.AddWithValue("@id", director.Id);
            sqlCommand.Parameters.AddWithValue("@Name", director.Name);


            int rowsAffected = sqlCommand.ExecuteNonQuery();
            return rowsAffected;
        }
        #endregion

        #region Insert New Director
        public int InsertEntity(SqlCommand sqlCommand, Director director)
        {
            sqlCommand.Parameters.AddWithValue("@Name", director.Name);
            sqlCommand.Parameters.AddWithValue("@creation_date", director.Created);
            sqlCommand.Parameters.AddWithValue("@isDeleted", director.isDeleted);

            int rowsAffected = sqlCommand.ExecuteNonQuery();
            return rowsAffected;
        }
        #endregion

        #region Delete Director
        // delete
        public int ExecuteNonQueryDelete(string query, int id)
        {
            var cmd = command(query);
            var director = ExcuteReader(Queries.SelectDirectorByIdQuery, id);
            if (director.Count > 0)
            {
                return DeleteEntity(cmd, director.FirstOrDefault());
            }
            return 0;
        }
        public int DeleteEntity(SqlCommand sqlCommand, Director director)
        {
            sqlCommand.Parameters.AddWithValue("@id", director.Id);
            sqlCommand.Parameters.AddWithValue("@isDeleted", true);
            int rowsAffected = sqlCommand.ExecuteNonQuery();
            return rowsAffected;

        }
        #endregion
    }
}
