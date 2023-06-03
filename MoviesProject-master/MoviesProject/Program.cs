using MoviesProject.BusinessLayer;
using MoviesProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesProject
{
    internal class Program
    {
        public static readonly MoviesCRUD MovieOp = MoviesCRUD.Instance;

        static void Main(string[] args)
        {


            //#region Get All Movies
            //Console.WriteLine("Get All Movies ");
            //var movies = MovieOp.GetAll();
            //foreach (var movie in movies)
            //{
            //    Console.Write(movie.Id);
            //    Console.Write(movie.Name);
            //    Console.Write(movie.Description);
            //    Console.Write(movie.Publish_date);
            //    Console.Write(movie.Director_Id);
            //    Console.WriteLine(movie.Rating_Id);
            //}
            // #endregion
            //Console.WriteLine("-----------------------------");
            //Console.WriteLine("Get Movie by ID");
            //#region Get Movie by ID
            //var movieById = MovieOp.GetAll(5);
            //foreach (var movie in movieById)
            //{
            //    Console.Write(movie.Id);
            //    Console.Write(movie.Name);
            //    Console.Write(movie.Description);
            //    Console.Write(movie.Publish_date);
            //    Console.Write(movie.Director_Id);
            //    Console.WriteLine(movie.Rating_Id);
            //}
            //#endregion

            #region Update Movie 
            //var movie = new Movie();
            //movie.Id = 4;
            //movie.Name = "new Movie";
            //movie.Description = "Movie Description new";
            //movie.Publish_date = "09-10-2010";
            //movie.Created = DateTime.Now;
            //movie.Director_Id = 2;
            //movie.Rating_Id = 2;

            //MovieOp.UpdateMovie(movie);
            #endregion

            #region Insert New Movie
            //var movie2 = new Movies();
            //movie2.Name = "new Movie2";
            //movie2.Description = "Movie Description new22222";
            //movie2.Publish_date = "10-10-2023";
            //movie2.Created = DateTime.Now;
            //movie2.Director_Id = 1;
            //movie2.Rating_Id = 2;
            //movie2.isDeleted = false;
            //MovieOp.AddNewMovie(movie2);
            #endregion

            //#region Delete Movie
            ////int movie_id = 4;
            ////MovieOp.DeleteMovie(movie_id);
            //#endregion

            void Start()
            {
                Console.WriteLine("Enter Your name ");
                string name = Console.ReadLine();
                Console.WriteLine($"Welcome {name} to the Movies Application!\n");

                string input;
                do
                {
                    Console.WriteLine($"\n{name}, please selectan option: \n1- Users \n2- Admin \n-1 to exit");
                    input = Console.ReadLine();

                    switch (input)
                    {
                        case "1":
                            PresentationLayer.User.Users();
                            break;
                        case "2":
                            PresentationLayer.Admin.Admins();
                            break;
                        case "-1":
                            Console.WriteLine("Exiting...");
                            break;
                        default:
                            Console.WriteLine("Invalid input. Please enter 1, 2, or -1.");
                            break;
                    }
                } while (input != "-1");
            }

            Start();
            Console.Read();
        }
    }
}
