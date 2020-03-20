using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOVIE_NIGHT
{
    public static class DalManager
    {
        private static string cs = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MoviesAndActors;Integrated Security=True";
        /// <summary>
        /// Den her metode returnere en liste med alle filmene.
        /// </summary>
        /// <returns></returns>
        public static List<Movie> GetMovies()
        {
            List<Movie> movies = new List<Movie>();
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT ID, Title, Genre, Description, Length, Release_year FROM Movie", connection);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int id = (int)rdr["ID"];
                    string title = (string)rdr["Title"];
                    string genre = (string)rdr["Genre"];
                    string description = (string)rdr["Description"];
                    string length = (string)rdr["Length"];
                    string releaseYear = (string)rdr["Release_year"];

                    Movie m = new Movie(id, title, genre, description, length, releaseYear);
                    movies.Add(m);
                }
            }
            return movies;
        }
        /// <summary>
        /// Den her metode returnere en liste med alle filmene indenfor dit søgekriterie.
        /// </summary>
        /// <returns></returns>
        public static List<Movie> GetMoviesSearch(string search)
        {
            List<Movie> movies = new List<Movie>();
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT ID, Title, Genre, Description, Length, Release_year FROM Movie WHERE Title LIKE @search", connection);
                SqlParameter sp = new SqlParameter();
                sp.ParameterName = "@search";
                sp.Value = "%" + search + "%";
                cmd.Parameters.Add(sp);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int id = (int)rdr["ID"];
                    string title = (string)rdr["Title"];
                    string genre = (string)rdr["Genre"];
                    string description = (string)rdr["Description"];
                    string length = (string)rdr["Length"];
                    string releaseYear = (string)rdr["Release_year"];

                    Movie m = new Movie(id, title, genre, description, length, releaseYear);
                    movies.Add(m);
                }
            }
            return movies;
        }
        /// <summary>
        /// Den her metode returnere en liste med alle filmene indenfor dit søgekriterie indenfor genre.
        /// </summary>
        /// <returns></returns>
        public static List<Movie> GetMoviesSearchGenre(string search)
        {
            List<Movie> movies = new List<Movie>();
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT ID, Title, Genre, Description, Length, Release_year FROM Movie WHERE Genre LIKE @search", connection);
                SqlParameter sp = new SqlParameter();
                sp.ParameterName = "@search";
                sp.Value = "%" + search + "%";
                cmd.Parameters.Add(sp);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int id = (int)rdr["ID"];
                    string title = (string)rdr["Title"];
                    string genre = (string)rdr["Genre"];
                    string description = (string)rdr["Description"];
                    string length = (string)rdr["Length"];
                    string releaseYear = (string)rdr["Release_year"];

                    Movie m = new Movie(id, title, genre, description, length, releaseYear);
                    movies.Add(m);
                }
            }
            return movies;
        }
        /// <summary>
        /// Den her metode opretter en ny film i databasen.
        /// </summary>
        /// <returns></returns>
        public static Movie InsertMovie(Movie m)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Movie(Title, Genre, Description, Length, Release_year) OUTPUT INSERTED.ID VALUES(@t, @g, @d, @l, @r)", connection);

                cmd.Parameters.Add(new SqlParameter("@t", m.Title));
                cmd.Parameters.Add(new SqlParameter("@g", m.Genre));
                cmd.Parameters.Add(new SqlParameter("@d", m.Description));
                cmd.Parameters.Add(new SqlParameter("@l", m.Length));
                cmd.Parameters.Add(new SqlParameter("@r", m.ReleaseYear));

                int newId = (Int32)cmd.ExecuteScalar();
                m.Id = newId;
            }
            return m;
        }
        /// <summary>
        /// Den her metode updatere en film på databasen.
        /// </summary>
        /// <returns></returns>
        public static Movie EditMovie(Movie m)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Movie SET Title = @t, Genre = @g, Description = @d, Length = @l, Release_year = @r WHERE ID = @ID", connection);

                cmd.Parameters.Add(new SqlParameter("@ID", m.Id));
                cmd.Parameters.Add(new SqlParameter("@t", m.Title));
                cmd.Parameters.Add(new SqlParameter("@g", m.Genre));
                cmd.Parameters.Add(new SqlParameter("@d", m.Description));
                cmd.Parameters.Add(new SqlParameter("@l", m.Length));
                cmd.Parameters.Add(new SqlParameter("@r", m.ReleaseYear));
                cmd.ExecuteNonQuery();
            }
            return m;
        }
        /// <summary>
        /// Den her metode sletter en film på databasen.
        /// </summary>
        /// <returns></returns>
        public static void DeleteMovie(int id)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Movie WHERE ID = @ID", connection);

                cmd.Parameters.Add(new SqlParameter("@ID", id));
                cmd.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// Den her metode returnere en liste med alle skuespillerne.
        /// </summary>
        /// <returns></returns>
        public static List<Actor> GetActors()
        {
            List<Actor> actors = new List<Actor>();
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT ID, Firstname, Lastname FROM Actor", connection);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int id = (int)rdr["ID"];
                    string firstname = (string)rdr["Firstname"];
                    string lastname = (string)rdr["Lastname"];

                    Actor a = new Actor(id, firstname, lastname);
                    actors.Add(a);
                }
            }
            return actors;
        }
        /// <summary>
        /// Den her metode returnere en liste med alle skuespillerne indenfor dit søgekriterie.
        /// </summary>
        /// <returns></returns>
        public static List<Actor> GetActorsSearch(string search)
        {
            List<Actor> actors = new List<Actor>();
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT ID, Firstname, Lastname FROM Actor WHERE Firstname LIKE @search OR Lastname LIKE @search", connection);
                SqlParameter sp = new SqlParameter();
                sp.ParameterName = "@search";
                sp.Value = "%" + search + "%";
                cmd.Parameters.Add(sp);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int id = (int)rdr["ID"];
                    string firstname = (string)rdr["Firstname"];
                    string lastname = (string)rdr["Lastname"];

                    Actor a = new Actor(id, firstname, lastname);
                    actors.Add(a);
                }
            }
            return actors;
        }
        /// <summary>
        /// Den her metode opretter en ny skuespiller i databasen.
        /// </summary>
        /// <returns></returns>
        public static Actor InsertActor(Actor a)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Actor(Firstname, Lastname) OUTPUT INSERTED.ID VALUES(@fn,@ln)", connection);

                cmd.Parameters.Add(new SqlParameter("@fn", a.Firstname));
                cmd.Parameters.Add(new SqlParameter("@ln", a.Lastname));
                int newId = (Int32)cmd.ExecuteScalar();
                a.Id = newId;
            }
            return a;
        }
        /// <summary>
        /// Den her metode updatere en skespiller i databasen.
        /// </summary>
        /// <returns></returns>
        public static Actor EditActor(Actor a)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Actor SET Firstname = @fn, Lastname = @ln WHERE ID = @ID", connection);

                cmd.Parameters.Add(new SqlParameter("@ID", a.Id));
                cmd.Parameters.Add(new SqlParameter("@fn", a.Firstname));
                cmd.Parameters.Add(new SqlParameter("@ln", a.Lastname));
                cmd.ExecuteNonQuery();
            }
            return a;
        }
        /// <summary>
        /// Den her metode sletter en skespiller i databasen.
        /// </summary>
        /// <returns></returns>
        public static void DeleteActor(int id)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Actor WHERE ID = @ID", connection);

                cmd.Parameters.Add(new SqlParameter("@ID", id));
                cmd.ExecuteNonQuery();
            }
        }
    }
}