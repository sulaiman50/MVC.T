using MoviesProject.Constants;
using MoviesProject.DBLayer;
using MoviesProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesProject.BusinessLayer
{
    public class MoviesCRUD: MoivesRepo
    {
        public static readonly MoviesCRUD Instance  = new MoviesCRUD();

        // GET ALL Movies OR Get Movie By ID
        public List<Movie> GetAll(int? id = null)
        {
            return id !=null ? ExcuteReader(Queries.SelectMovieByIdQuery, id) : ExcuteReader(Queries.SelectAllMoviesQuery);
        }


        // update 
        public void UpdateMovie(Movie movie)
        {
            var result = ExecuteNonQuery(Queries.UpdateMovieQuery, movie, true);
            if (result > 0)
            {
                // Update successful
                Console.WriteLine("Movie updated successfully.");
            }
            else
            {
                // No rows affected, update failed
                Console.WriteLine("No rows updated.");
            }
        }



        // insert
        public void AddNewMovie(Movie movie)
        {
            var result = ExecuteNonQuery(Queries.InsertMovieQuery, movie, false);
            if (result > 0)
            {
                // Update successful
                Console.WriteLine("New movie added successfully.");
            }
            else
            {
                // No rows affected, insert failed
                Console.WriteLine("Error adding new movie.");
            }
        }



        // delete
        public void DeleteMovie(int id)
        {

            var result = ExecuteNonQueryDelete(Queries.DeleteMovieQuery, id);
            if (result > 0)
            {
                // Update successful
                Console.WriteLine("Movie is deleted successfully.");
            }
            else
            {
                // No rows affected, insert failed
                Console.WriteLine("Error deleting movie.");
            }
        }

    }
}
