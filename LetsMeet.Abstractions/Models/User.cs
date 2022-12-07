namespace LetsMeet.Abstractions.Models
{
	using System;
	using LetsMeet.Abstractions.Models;

	public class User
	{
		public Guid UserId

		{
			get;
			set;
		}

		public string FirstName

		{
			get;
			set;
		}

		public string LastName

		{
			get;
			set;
		}

		public int Age

		{
			get;
			set;
		}

		public bool IsFeatured

		{
			get;
			set;
		}

		public string Location

		{
			get;
			set;
		}

		public DateTime CreatedDate

		{
			get;
			set;
		}

		public DateTime ModifiedDate

		{
			get;
			set;
		}
	}
}
