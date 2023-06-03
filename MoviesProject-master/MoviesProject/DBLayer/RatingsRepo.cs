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
    public class RatingsRepo : BaseRepo
    {
        public SqlCommand command(string query)
        {
            var connection = GetConnection();
            OpenConnection(connection);
            return new SqlCommand(query, connection);
        }

        public List<Rating> ExcuteReader(string query, int? id = null)
        {
            var cmd = command(query);
            if (id != null)
            {
                cmd.Parameters.AddWithValue("@id", id);
                return ReadEntity(cmd.ExecuteReader(), id);
            }
            return ReadEntity(cmd.ExecuteReader());

        }

        // Read Rating
        public List<Rating> ReadEntity(SqlDataReader rdr, int? id = null)
        {
            var list = new List<Rating>();

            while (rdr.Read())
            {
                var result = new Rating();

                result.Id = Convert.ToInt32(rdr[0]);
                result.Name = rdr[1].ToString() != null ? rdr[1].ToString() : null;

                list.Add(result);
            }
            return list;
        }

        public int ExecuteNonQuery(string query, Rating rating, bool updated)
        {
            var cmd = command(query);
            if (updated == true)
            {
                var selectMovie = ExcuteReader(Queries.SelectRatingByIdQuery, rating.Id);
                if (selectMovie.Count() > 0)
                {
                    return UpdateEntity(cmd, rating);
                }
            }
            else
            {
                return InsertEntity(cmd, rating);
            }
            return 0;
        }

        #region update Rating
        public int UpdateEntity(SqlCommand sqlCommand, Rating rating)
        {

            sqlCommand.Parameters.AddWithValue("@id", rating.Id);
            sqlCommand.Parameters.AddWithValue("@Name", rating.Name);


            int rowsAffected = sqlCommand.ExecuteNonQuery();
            return rowsAffected;
        }
        #endregion

        #region Insert New Rating
        public int InsertEntity(SqlCommand sqlCommand, Rating rating)
        {
            sqlCommand.Parameters.AddWithValue("@Name", rating.Name);
            sqlCommand.Parameters.AddWithValue("@creation_date", rating.Created);
            sqlCommand.Parameters.AddWithValue("@isDeleted", rating.isDeleted);

            int rowsAffected = sqlCommand.ExecuteNonQuery();
            return rowsAffected;
        }
        #endregion

        #region Delete Rating
        // delete
        public int ExecuteNonQueryDelete(string query, int id)
        {
            var cmd = command(query);
            var rating = ExcuteReader(Queries.SelectRatingByIdQuery, id);
            if (rating.Count > 0)
            {
                return DeleteEntity(cmd, rating.FirstOrDefault());
            }
            return 0;
        }
        public int DeleteEntity(SqlCommand sqlCommand, Rating rating)
        {
            sqlCommand.Parameters.AddWithValue("@id", rating.Id);
            sqlCommand.Parameters.AddWithValue("@isDeleted", true);
            int rowsAffected = sqlCommand.ExecuteNonQuery();
            return rowsAffected;

        }
        #endregion
    }
}
