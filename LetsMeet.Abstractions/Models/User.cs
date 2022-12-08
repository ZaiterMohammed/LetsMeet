namespace LetsMeet.Abstractions.Models
{
	using System;

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

		public int IsFeatured
		{
			get;
			set;
		}

		public Country Country
		{
			get;
			set;
		}

        public City City
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

        public Guid CompanyId
        {
            get;
            set;
        }

        public Guid OrganisationId
        {
            get;
            set;
        }
    }
}
