namespace LetsMeet.Abstractions.Models
{
	using System;

	public class CreateRequestUser
    {
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

		public int IsFeatured
		{
			get;
			set;
		}

		public Guid CountryId
		{
			get;
			set;
		}

        public Guid CityId
        {
            get;
            set;
        }
    }
}
