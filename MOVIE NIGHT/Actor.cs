using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOVIE_NIGHT
{
    public class Actor
    {
		private int id;
		private string firstname;
		private string lastname;

		public int Id
		{
			get { return id; }
			set { id = value; }
		}
		public string Firstname
		{
			get { return firstname; }
			set { firstname = value; }
		}
		public string Lastname
		{
			get { return lastname; }
			set { lastname = value; }
		}

		public Actor(string firstname, string lastname)
		{
			this.firstname = firstname;
			this.lastname = lastname;
		}

		public Actor(int id, string firstname, string lastname)
			: this(firstname, lastname)
		{
			this.id = id;
		}
	}
}
