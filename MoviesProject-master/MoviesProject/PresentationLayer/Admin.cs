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
    public class Admin
    {

        public static void Admins()
        {
            string input;
            do
            {
                Console.WriteLine("\nPlease select a query:");
                Console.WriteLine("\nFor Movies table : \n1- Display all movies\n2- Select movie by ID\n3- Add new movie\n4- Update movie\n5- Delete movie\n");
                Console.WriteLine("\nFor Ratings table :\n6- Display all ratings \n7- Select rating by id\n8- Add new rating\n9- Update rating\n10- Delete rating\n");
                Console.WriteLine("\nFor Directors table: \n11- Display all directors\n12- Select director by id \n13- Add new director\n14- Update director\n15- Delete director\n-1 to back\n");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        User.AllMovies();
                        break;
                    case "2":
                        User.MovieByID();
                        break;
                    case "3":
                        AddNewMovie();
                        break;
                    case "4":
                        UpdateMovie();
                        break;
                    case "5":
                        DeleteMovie();
                        break;
                    case "6":
                        User.AllRatings();
                        break;
                    case "7":
                        User.RatingsByID();
                        break;
                    case "8":
                        AddNewRating();
                        break;
                    case "9":
                        UpdateRating();
                        break;
                    case "10":
                        DeleteRating();
                        break;
                    case "11":
                        User.AllDirectors();
                        break;
                    case "12":
                        User.DirectorByID();
                        break;
                    case "13":
                        AddNewDirector();
                        break;
                    case "14":
                        UpdateDirector();
                        break;
                    case "15":
                        DeleteDirector();
                        break;
                    case "-1":
                        Console.WriteLine("Back...");
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please enter a valid option or -1 to exit.");
                        break;
                }
            } while (input != "-1");
        }

        public static void AddNewMovie()
        {
            Console.WriteLine("Enter the name of the movie:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter the description of the movie:");
            string description = Console.ReadLine();

            Console.WriteLine("Enter the publish date of the movie:");
            string publishDate = Console.ReadLine();
            //DateTime publishDate;
            //if (!DateTime.TryParse(publishDateStr, out publishDate))
            //{
            //    Console.WriteLine("Invalid date format. Please enter the publish date of the movie as YYYY-MM-DD.");
            //    return;
            //}

            Console.WriteLine("Enter the ID of the director of the movie:");
            string directorIdStr = Console.ReadLine();
            int directorId;
            if (!int.TryParse(directorIdStr, out directorId))
            {
                Console.WriteLine("Invalid input. Please enter a valid numeric director ID.");
                return;
            }

            Console.WriteLine("Enter the ID of the rating of the movie:");
            string ratingIdStr = Console.ReadLine();
            int ratingId;
            if (!int.TryParse(ratingIdStr, out ratingId))
            {
                Console.WriteLine("Invalid input. Please enter a valid numeric rating ID.");
                return;
            }



            var moviesCRUD = MoviesCRUD.Instance;
            var movie = new Movie
            {
                Name = name,
                Description = description,
                Publish_date = publishDate,
                Created = DateTime.Now,
                Director_Id = directorId,
                Rating_Id = ratingId,
                isDeleted = false
            };
            moviesCRUD.AddNewMovie(movie);
            

        }


        public static void UpdateMovie()
        {
            Console.WriteLine("Enter the ID of the movie to update:");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid input. Please enter a valid numeric ID.");
                return;
            }


            var moviesCRUD = MoviesCRUD.Instance;

            var movie = moviesCRUD.GetAll(id);

            if (movie == null)
            {
                Console.WriteLine($"Movie with ID {id} not found.");
                return;
            }


            Console.WriteLine("Enter the new name of the movie:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter the new description of the movie:");
            string description = Console.ReadLine();

            Console.WriteLine("Enter the new publish date of the movie (yyyy-mm-dd):");
            string publishDate = Console.ReadLine();
            // if(DateTime.TryParseExact(Console.ReadLine(),"yyyy-mm-dd", null, System.Globalization.DateTimeStyles., out publishDate))
            //// if (!DateTime.TryParse(Console.ReadLine(), out publishDate))
            // {
            //     Console.WriteLine("Invalid input. Please enter a valid date in the format yyyy-mm-dd.");
            //     return;
            // }

            Console.WriteLine("Enter the new director ID of the movie:");
            int directorId;
            if (!int.TryParse(Console.ReadLine(), out directorId))
            {
                Console.WriteLine("Invalid input. Please enter a valid numeric director ID.");
                return;
            }

            Console.WriteLine("Enter the new rating ID of the movie:");
            int ratingId;
            if (!int.TryParse(Console.ReadLine(), out ratingId))
            {
                Console.WriteLine("Invalid input. Please enter a valid numeric rating ID.");
                return;
            }

            var updateMovie = new Movie();
            updateMovie.Id = id;
            updateMovie.Name = name;
            updateMovie.Description = description;
            updateMovie.Publish_date = publishDate;
            updateMovie.Created = DateTime.Now;
            updateMovie.Director_Id = directorId;
            updateMovie.Rating_Id = ratingId;

            moviesCRUD.UpdateMovie(updateMovie);

            //if (moviesCRUD.UpdateMovie(updateMovie))
            //{
            //    Console.WriteLine($"Movie with ID {id} updated successfully.");
            //}
            //else
            //{
            //    Console.WriteLine($"Error updating movie with ID {id}. Please try again.");
            //}

        }

        public static void DeleteMovie()
        {
            Console.WriteLine("Enter the ID of the movie to delete:");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid input. Please enter a valid numeric ID.");
                return;
            }


            var moviesCRUD = MoviesCRUD.Instance;
            var movie = moviesCRUD.GetAll(id);

            if (movie == null)
            {
                Console.WriteLine($"Movie with ID {id} not found.");
                return;
            }

            moviesCRUD.DeleteMovie(id);
            //if ()
            //{
            //    Console.WriteLine($"Movie with ID {id} deleted successfully.");
            //}
            //else
            //{
            //    Console.WriteLine($"Error deleting movie with ID {id}. Please try again.");
            //}

        }

        public static void AddNewRating()
        {
            Console.WriteLine("Enter the name of the rating:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter the description of the rating:");
            string description = Console.ReadLine();


            var ratingsCRUD = RatingCRUD.Instance;
            var rating = new Rating
            {
                Name = name,
                Created = DateTime.Now,
                isDeleted = false
            };

            ratingsCRUD.AddNewRating(rating);
            //if ()
            //{
            //    Console.WriteLine("Rating added successfully.");
            //}
            //else
            //{
            //    Console.WriteLine("Error adding rating. Please try again.");
            //}

        }

        public static void UpdateRating()
        {
            Console.WriteLine("Enter the ID of the rating to update:");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid input. Please enter a valid numeric ID.");
                return;
            }


            var ratingsCRUD = RatingCRUD.Instance;
            var rating = ratingsCRUD.GetAll(id);

            if (rating == null)
            {
                Console.WriteLine($"Rating with ID {id} not found.");
                return;
            }

            Console.WriteLine("Enter the new name of the rating:");
            string name = Console.ReadLine();

            var updatedRating = new Rating();
            updatedRating.Id = id;
            updatedRating.Name = name;

            ratingsCRUD.UpdateRating(updatedRating);
            //if ()
            //{
            //    Console.WriteLine($"Rating with ID {id} updated successfully.");
            //}
            //else
            //{
            //    Console.WriteLine($"Error updating rating with ID {id}. Please try again.");
            //}

        }

        public static void DeleteRating()
        {
            Console.WriteLine("Enter the ID of the rating to delete:");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid input. Please enter a valid numeric ID.");
                return;
            }

            var ratingsCRUD = RatingCRUD.Instance;
            var rating = ratingsCRUD.GetAll(id);

            if (rating == null)
            {
                Console.WriteLine($"Rating with ID {id} not found.");
                return;
            }

            ratingsCRUD.DeleteRating(id);
            //if ())
            //{
            //    Console.WriteLine($"Rating with ID {id} deleted successfully.");
            //}
            //else
            //{
            //    Console.WriteLine($"Error deleting rating with ID {id}. Please try again.");
            //}

        }


        public static void AddNewDirector()
        {
            Console.WriteLine("Enter the name of the director:");
            string name = Console.ReadLine();

            var directorsCRUD = DirectorsCRUD.Instance;
            var director = new Director
            {
                Name = name,
                Created = DateTime.Now,
                isDeleted = false
            };

            directorsCRUD.AddNewDirector(director);
            //if 
            //{
            //    Console.WriteLine("Director added successfully.");
            //}
            //else
            //{
            //    Console.WriteLine("Error adding director. Please try again.");
            //}

        }

        public static void UpdateDirector()
        {
            Console.WriteLine("Enter the ID of the director to update:");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid input. Please enter a valid numeric ID.");
                return;
            }


            var directorsCRUD = DirectorsCRUD.Instance;
            var director = directorsCRUD.GetAll(id);

            if (director == null)
            {
                Console.WriteLine($"Director with ID {id} not found.");
                return;
            }

            Console.WriteLine("Enter the new name of the director:");
            string name = Console.ReadLine();
         

            var updatedDiretor = new Director();
            updatedDiretor.Id = id;
            updatedDiretor.Name = name;

            directorsCRUD.UpdateDirector(updatedDiretor);
            //if ()
            //{
            //    Console.WriteLine($"Director with ID {id} updated successfully.");
            //}
            //else
            //{
            //    Console.WriteLine($"Error updating director with ID {id}. Please try again.");
            //}

        }

        public static void DeleteDirector()
        {
            Console.WriteLine("Enter the ID of the director to delete:");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid input. Please enter a valid numeric ID.");
                return;
            }


            var directorsCRUD = DirectorsCRUD.Instance;
            var director = directorsCRUD.GetAll(id);

            if (director == null)
            {
                Console.WriteLine($"Director with ID {id} not found.");
                return;
            }
            directorsCRUD.DeleteDirector(id);
            //if ()
            //{
            //    Console.WriteLine($"Director with ID {id} deleted successfully.");
            //}
            //else
            //{
            //    Console.WriteLine($"Error deleting director with ID {id}. Please try again.");
            //}

        }



    }
}