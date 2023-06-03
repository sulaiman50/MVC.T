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
    public class DirectorsCRUD : DirectorsRepo
    {
        public static readonly DirectorsCRUD Instance = new DirectorsCRUD();

        // GET ALL Directors OR Get Director By ID
        public List<Director> GetAll(int? id = null)
        {
            return id != null ? ExcuteReader(Queries.SelectDirectorByIdQuery, id) : ExcuteReader(Queries.SelectAllDirectorsQuery);
        }


        // update 
        public void UpdateDirector(Director director)
        {
            var result = ExecuteNonQuery(Queries.UpdateDirectorQuery, director, true);
            if (result > 0)
            {
                // Update successful
                Console.WriteLine("Director updated successfully.");
            }
            else
            {
                // No rows affected, update failed
                Console.WriteLine("No rows updated.");
            }
        }



        // insert
        public void AddNewDirector(Director director)
        {
            var result = ExecuteNonQuery(Queries.InsertDirectorQuery, director, false);
            if (result > 0)
            {
                // Update successful
                Console.WriteLine("New director added successfully.");
            }
            else
            {
                // No rows affected, insert failed
                Console.WriteLine("Error adding new director.");
            }
        }



        // delete
        public void DeleteDirector(int id)
        {

            var result = ExecuteNonQueryDelete(Queries.DeleteDirectorQuery, id);
            if (result > 0)
            {
                // Update successful
                Console.WriteLine("Director is deleted successfully.");
            }
            else
            {
                // No rows affected, insert failed
                Console.WriteLine("Error deleting director.");
            }
        }
    }
}
