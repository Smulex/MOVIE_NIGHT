using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOVIE_NIGHT
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();

                Console.WriteLine("Choose what you wanna do with the database.\n");
                Console.WriteLine("\t1 - To see all movies");
                Console.WriteLine("\t2 - To search in all movies");
                Console.WriteLine("\t3 - To search in all movies by genre");
                Console.WriteLine("\t4 - To see all actors");
                Console.WriteLine("\t5 - To search in all actors");

                Console.WriteLine("\n\tM - Add Movie");
                Console.WriteLine("\tN - Edit Movie");
                Console.WriteLine("\tB - Delete Movie");

                Console.WriteLine("\n\tA - Add actor");
                Console.WriteLine("\tS - Edit actor");
                Console.WriteLine("\tD - Delete actor");

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        List<Movie> movie = MovieManager.Movies();
                        foreach (Movie item in movie)
                        {
                            Console.Write(item.Title + " ");
                            Console.WriteLine(item.Length);
                        }
                        break;
                    case ConsoleKey.D2:
                        Console.Write("Search after a title: ");
                        string searchMovie = Console.ReadLine();
                        List<Movie> movieSearch = MovieManager.MoviesSearch(searchMovie);
                        foreach (Movie item in movieSearch)
                        {
                            Console.Write(item.Title + " ");
                            Console.WriteLine(item.Length);
                        }
                        break;
                    case ConsoleKey.D3:
                        Console.Write("Search after a genre: ");
                        string searchMovieGenre = Console.ReadLine();
                        List<Movie> movieSearchGenre = MovieManager.MoviesSearchGenre(searchMovieGenre);
                        foreach (Movie item in movieSearchGenre)
                        {
                            Console.Write("Title: " + item.Title + ". ");
                            Console.WriteLine("Genre: " + item.Genre);
                        }
                        break;
                    case ConsoleKey.D4:
                        List<Actor> actor = MovieManager.Actors();
                        foreach (Actor item in actor)
                        {
                            Console.WriteLine(item.Firstname + " " + item.Lastname);
                        }
                        break;
                    case ConsoleKey.D5:
                        Console.Write("Search after an Actor: ");
                        string searchActor = Console.ReadLine();
                        List<Actor> actorSearch = MovieManager.ActorsSearch(searchActor);
                        foreach (Actor item in actorSearch)
                        {
                            Console.WriteLine(item.Firstname + " " + item.Lastname);
                        }
                        break;
                    case ConsoleKey.M:
                        Console.Write("Enter the title of the movie: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter genre on the movie: ");
                        string genre = Console.ReadLine();
                        Console.Write("Enter the description on the movie: ");
                        string description = Console.ReadLine();
                        Console.Write("Enter the length of the movie (eg. 1h 28min): ");
                        string length = Console.ReadLine();
                        Console.Write("Enter release year on the movie: ");
                        string releaseYear = Console.ReadLine();
                        MovieManager.InsertMovie(title, genre, description, length, releaseYear);
                        break;
                    case ConsoleKey.N:
                        Console.Write("Enter the ID for the movie to edit: ");
                        int editMovie = Int32.Parse(Console.ReadLine());
                        Console.Write("Enter the title of the movie: ");
                        string editTitle = Console.ReadLine();
                        Console.Write("Enter genre on the movie: ");
                        string editGenre = Console.ReadLine();
                        Console.Write("Enter the description on the movie: ");
                        string editDescription = Console.ReadLine();
                        Console.Write("Enter the length of the movie (eg. 1h 28min): ");
                        string editLength = Console.ReadLine();
                        Console.Write("Enter release year on the movie: ");
                        string editReleaseYear = Console.ReadLine();
                        MovieManager.EditMovie(editMovie, editTitle, editGenre, editDescription, editLength, editReleaseYear);
                        break;
                    case ConsoleKey.B:
                        Console.Write("To delete a movie enter the movie's ID: ");
                        int deleteMovie = Int32.Parse(Console.ReadLine());
                        MovieManager.DeleteMovie(deleteMovie);
                        break;
                    case ConsoleKey.A:
                        Console.Write("Enter the actor's first name: ");
                        string firstname = Console.ReadLine();
                        Console.Write("Enter the actor's last name: ");
                        string lastname = Console.ReadLine();
                        MovieManager.InsertActor(firstname, lastname);
                        break;
                    case ConsoleKey.S:
                        Console.Write("Enter the ID for the actor to edit: ");
                        int editactor = Int32.Parse(Console.ReadLine());
                        Console.Write("To edit enter the actor's new first name: ");
                        string editFirstname = Console.ReadLine();
                        Console.Write("To edit enter the actor's new last name: ");
                        string editLastname = Console.ReadLine();
                        MovieManager.EditActor(editactor, editFirstname, editLastname);
                        break;
                    case ConsoleKey.D:
                        Console.Write("To delete an actor enter the actor's ID: ");
                        int deleteActor = Int32.Parse(Console.ReadLine());
                        MovieManager.DeleteActor(deleteActor);
                        break;
                    default:
                        break;
                }
                Console.ReadKey();
            } while (true);
        }
    }
}
