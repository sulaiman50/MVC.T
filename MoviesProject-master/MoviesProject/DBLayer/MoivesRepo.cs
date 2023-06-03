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
    public class MoivesRepo : BaseRepo
    {
        public SqlCommand command(string query)
        {
            var connection = GetConnection();
            OpenConnection(connection);
            return new SqlCommand(query, connection);
        }

        public List<Movie> ExcuteReader(string query, int? id = null)
        {
            var cmd = command(query);
            if (id != null)
            {
                cmd.Parameters.AddWithValue("@id", id);
            }
            return ReadEntity(cmd.ExecuteReader());

        }

        // Read Movie
        public List<Movie> ReadEntity(SqlDataReader rdr)
        {
            var list = new List<Movie>();

            while (rdr.Read())
            {
                var result = new Movie();

                result.Id = Convert.ToInt32(rdr[0]);
                result.Name = rdr[1].ToString() != null ? rdr[1].ToString() : null;
                result.Description = rdr[2].ToString();
                result.Publish_date = rdr[3].ToString();
                result.Director_Id = Convert.ToInt32(rdr[5]);
                result.Rating_Id = Convert.ToInt32(rdr[6]);

                list.Add(result);
            }
            return list;
        }



        public int ExecuteNonQuery(string query, Movie movie, bool updated)
        {
            var cmd = command(query);
            if (updated == true)
            {
                var selectMovie = ExcuteReader(Queries.SelectMovieByIdQuery, movie.Id);
                if (selectMovie.Count() > 0)
                {
                    return UpdateEntity(cmd, movie);
                }
            }
            else
            {
                return InsertEntity(cmd, movie);
            }
            return 0;
        }

        #region update Movie
        public int UpdateEntity(SqlCommand sqlCommand, Movie movie)
        {

            sqlCommand.Parameters.AddWithValue("@id", movie.Id);
            sqlCommand.Parameters.AddWithValue("@Name", movie.Name);
            sqlCommand.Parameters.AddWithValue("@Description", movie.Description);
            sqlCommand.Parameters.AddWithValue("@Publish_Date", movie.Publish_date);
            sqlCommand.Parameters.AddWithValue("@creation_date", movie.Created);
            sqlCommand.Parameters.AddWithValue("@Director_Id", movie.Director_Id);
            sqlCommand.Parameters.AddWithValue("@Rating_Id", movie.Rating_Id);


            int rowsAffected = sqlCommand.ExecuteNonQuery();
            return rowsAffected;
        }
        #endregion

        // insert
        #region Insert New Movie
        public int InsertEntity(SqlCommand sqlCommand, Movie movie)
        {
            sqlCommand.Parameters.AddWithValue("@Name", movie.Name);
            sqlCommand.Parameters.AddWithValue("@Description", movie.Description);
            sqlCommand.Parameters.AddWithValue("@Publish_Date", movie.Publish_date);
            sqlCommand.Parameters.AddWithValue("@creation_date", movie.Created);
            sqlCommand.Parameters.AddWithValue("@Director_Id", movie.Director_Id);
            sqlCommand.Parameters.AddWithValue("@Rating_Id", movie.Rating_Id);
            sqlCommand.Parameters.AddWithValue("@isDeleted", movie.isDeleted);

            int rowsAffected = sqlCommand.ExecuteNonQuery();
            return rowsAffected;
        }
        #endregion

        #region Delete Movie
        public int ExecuteNonQueryDelete(string query, int id)
        {
            var cmd = command(query);
            var movie = ExcuteReader(Queries.SelectMovieByIdQuery, id);
            if (movie.Count > 0)
            {
                return DeleteEntity(cmd, movie.FirstOrDefault());
            }
            return 0;
        }
        public int DeleteEntity(SqlCommand sqlCommand, Movie movie)
        {
            sqlCommand.Parameters.AddWithValue("@id", movie.Id);
            sqlCommand.Parameters.AddWithValue("@isDeleted", true);
            int rowsAffected = sqlCommand.ExecuteNonQuery();
            return rowsAffected;
        }
        #endregion
    }
}
