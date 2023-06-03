using MoviesProject.BusinessLayer;
using MoviesProject.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesProject.PresentationLayer
{
    public class User
    {
        public static readonly MoviesCRUD MovieOp = MoviesCRUD.Instance;
        public static readonly DirectorsCRUD DirectorOp = DirectorsCRUD.Instance;
        public static readonly RatingCRUD RatingOp = RatingCRUD.Instance;

        public static void Users()
        {
            string input;
            do
            {
                Console.WriteLine("\nPlease select a query:\n1- Display all movies\n2- Select movie by ID\n3- Display all ratings \n4- Select rating by id\n5- Display all directors\n6- Select director by id \n-1 to back");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AllMovies();
                        break;
                    case "2":
                        MovieByID();
                        break;
                    case "3":
                        AllRatings();
                        break;
                    case "4":
                        RatingsByID();
                        break;
                    case "5":
                        AllDirectors();
                        break;
                    case "6":
                        DirectorByID();
                        break;
                    case "-1":
                        Console.WriteLine("Back...");
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please enter 1, 2, or -1.");
                        break;
                }
            } while (input != "-1");
        }




        public static void AllMovies()
        {
            var movies = MovieOp.GetAll();

            //checks if the collection is empty and contains no movies.
            if (movies.Count == 0)
            {
                Console.WriteLine("No movies found.");
            }
            else
            {
                Console.WriteLine("ID\tName\tDescription\tPublish Date\tDirector ID\tRating ID");
                foreach (var movie in movies)
                {
                    Console.WriteLine($"{movie.Id}\t{movie.Name}\t{movie.Description}\t{movie.Publish_date}\t{movie.Director_Id}\t{movie.Rating_Id}");
                }
            }
        }


        public static void MovieByID()
        {
            Console.WriteLine("Enter movie ID:");
            var input = Console.ReadLine();

            //validate user input and ensure that the input is a valid integer. 
            if (!int.TryParse(input, out int id))
            {
                Console.WriteLine("Invalid input. Please enter a numeric ID.");
            }
            else
            {

                var movie = MovieOp.GetAll(id).FirstOrDefault();
                if (movie == null)
                {
                    Console.WriteLine($"Movie with ID {id} not found.");
                }
                else
                {
                    Console.WriteLine("ID\tName\tDescription\tPublish Date\tDirector ID\tRating ID");
                    Console.WriteLine($"{movie.Id}\t{movie.Name}\t{movie.Description}\t{movie.Publish_date}\t{movie.Director_Id}\t{movie.Rating_Id}");
                }

            }
        }



        public static void AllRatings()
        {

            var ratings = RatingOp.GetAll();

            //checks if the collection is empty and contains no rating.
            if (ratings.Count == 0)
            {
                Console.WriteLine("No ratings found.");
            }
            else
            {
                Console.WriteLine("ID\tName");
                foreach (var rating in ratings)
                {
                    Console.WriteLine($"{rating.Id}\t{rating.Name}");
                }
            }


        }



        public static void RatingsByID()
        {

            Console.WriteLine("Enter rating ID:");
            var input = Console.ReadLine();

            if (!int.TryParse(input, out int id))
            {
                Console.WriteLine("Invalid input. Please enter a numeric rating ID.");
            }
            else
            {
                var rating = RatingOp.GetAll(id).FirstOrDefault();
                if (rating == null)
                {
                    Console.WriteLine($"Rating with ID {id} not found.");
                }
                else
                {
                    Console.WriteLine("ID\tName");
                    Console.WriteLine($"{rating.Id}\t{rating.Name}");
                }
            }

        }


        public static void AllDirectors()
        {

            var directors = DirectorOp.GetAll();

            if (directors.Count == 0)
            {
                Console.WriteLine("No directors found.");
            }
            else
            {
                Console.WriteLine("ID\tName\tBirth Year");
                foreach (var director in directors)
                {
                    Console.WriteLine($"{director.Id}\t{director.Name}\t{director.Created}");
                }
            }

        }

        public static void DirectorByID()
        {


            Console.WriteLine("Enter director ID:");
            var input = Console.ReadLine();

            if (!int.TryParse(input, out int id))
            {
                Console.WriteLine("Invalid input. Please enter a numeric director ID.");
            }
            else
            {
                var director = DirectorOp.GetAll(id).FirstOrDefault();
                if (director == null)
                {
                    Console.WriteLine($"Director with ID {id} not found.");
                }
                else
                {
                    Console.WriteLine("ID\tName\tBirth Year");
                    Console.WriteLine($"{director.Id}\t{director.Name}\t{director.Created}");
                }
            }

        }

    }
}