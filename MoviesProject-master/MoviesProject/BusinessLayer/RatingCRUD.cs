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
    public class RatingCRUD : RatingsRepo
    {
        public static readonly RatingCRUD Instance = new RatingCRUD();

        // GET ALL Rating OR Get Rating By ID
        public List<Rating> GetAll(int? id = null)
        {
            return id != null ? ExcuteReader(Queries.SelectRatingByIdQuery, id) : ExcuteReader(Queries.SelectAllRatingsQuery);
        }


        // update 
        public void UpdateRating(Rating rating)
        {
            var result = ExecuteNonQuery(Queries.UpdateRatingQuery, rating, true);
            if (result > 0)
            {
                // Update successful
                Console.WriteLine("Rating updated successfully.");
            }
            else
            {
                // No rows affected, update failed
                Console.WriteLine("No rows updated.");
            }
        }



        // insert
        public void AddNewRating(Rating rating)
        {
            var result = ExecuteNonQuery(Queries.InsertRatingQuery, rating, false);
            if (result > 0)
            {
                // Update successful
                Console.WriteLine("New rating added successfully.");
            }
            else
            {
                // No rows affected, insert failed
                Console.WriteLine("Error adding new rating.");
            }
        }



        // delete
        public void DeleteRating(int id)
        {

            var result = ExecuteNonQueryDelete(Queries.DeleteRatingQuery, id);
            if (result > 0)
            {
                // Update successful
                Console.WriteLine("Rating is deleted successfully.");
            }
            else
            {
                // No rows affected, insert failed
                Console.WriteLine("Error deleting rating.");
            }
        }
    }
}
