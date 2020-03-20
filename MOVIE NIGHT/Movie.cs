using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOVIE_NIGHT
{
    public class Movie
    {
        private int id;
        private string title;
        private string genre;
        private string description;
        private string length;
        private string releaseYear;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public string Length
        {
            get { return length; }
            set { length = value; }
        }
        public string ReleaseYear
        {
            get { return releaseYear; }
            set { releaseYear = value; }
        }

        public Movie(string title, string genre, string releaseYear)
        {
            this.title = title;
            this.genre = genre;
            this.releaseYear = releaseYear;
        }
        public Movie(string title, string genre, string description, string length, string releaseYear)
            : this(title, genre, releaseYear)
        {
            this.description = description;
            this.length = length;
        }

        public Movie(int id, string title, string genre, string description, string length, string releaseYear)
            : this(title, genre, description, length, releaseYear)
        {
            this.id = id;
        }
    }
}
