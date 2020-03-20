using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOVIE_NIGHT
{
    public static class MovieManager
    {
        /// <summary>
        /// Den her metode returnere en liste med alle filmene.
        /// </summary>
        /// <returns></returns>
        public static List<Movie> Movies()
        {
            return DalManager.GetMovies();
        }
        /// <summary>
        /// Den her metode returnere en liste med alle filmene indenfor dit søgekriterie.
        /// </summary>
        /// <returns></returns>
        public static List<Movie> MoviesSearch(string search)
        {
            return DalManager.GetMoviesSearch(search);
        }
        /// <summary>
        /// Den her metode returnere en liste med alle filmene indenfor dit søgekriterie indenfor genre.
        /// </summary>
        /// <returns></returns>
        public static List<Movie> MoviesSearchGenre(string search)
        {
            return DalManager.GetMoviesSearchGenre(search);
        }
        /// <summary>
        /// Den her metode opretter en ny film i databasen og laver objektet Movie.
        /// </summary>
        /// <returns></returns>
        public static Movie InsertMovie(string title, string genre, string description, string length, string releaseYear)
        {
            Movie m = new Movie(title, genre, description, length, releaseYear);
            return DalManager.InsertMovie(m);
        }
        /// <summary>
        /// Den her metode updatere en film på databasen.
        /// Jeg er itvivl om man skulle lave den som en void.
        /// </summary>
        /// <returns></returns>
        public static Movie EditMovie(int id, string title, string genre, string description, string length, string releaseYear)
        {
            Movie m = new Movie(id, title, genre, description, length, releaseYear);
            return DalManager.EditMovie(m);
        }
        /// <summary>
        /// Den her metode sletter en film på databasen.
        /// </summary>
        /// <returns></returns>
        public static void DeleteMovie(int id)
        {
            DalManager.DeleteMovie(id);
        }

        /// <summary>
        /// Den her metode returnere en liste med alle skuespillerne.
        /// </summary>
        /// <returns></returns>
        public static List<Actor> Actors()
        {
            return DalManager.GetActors();
        }
        /// <summary>
        /// Den her metode returnere en liste med alle skuespillerne indenfor dit søgekriterie.
        /// </summary>
        /// <returns></returns>
        public static List<Actor> ActorsSearch(string search)
        {
            return DalManager.GetActorsSearch(search);
        }
        /// <summary>
        /// Den her metode opretter en ny skuespiller i databasen og laver objektet Actor.
        /// </summary>
        /// <returns></returns>
        public static Actor InsertActor(string firstname, string lastname)
        {
            Actor a = new Actor(firstname, lastname);
            return DalManager.InsertActor(a);
        }
        /// <summary>
        /// Den her metode updatere en skespiller i databasen.
        /// Jeg er itvivl om man skulle lave den som en void eller en helt anden ting
        /// </summary>
        /// <returns></returns>
        public static Actor EditActor(int id, string firstname, string lastname)
        {
            Actor a = new Actor(id, firstname, lastname);
            return DalManager.EditActor(a);
        }
        /// <summary>
        /// Den her metode sletter en skespiller i databasen.
        /// </summary>
        /// <returns></returns>
        public static void DeleteActor(int id)
        {
            DalManager.DeleteActor(id);
        }
    }
}
