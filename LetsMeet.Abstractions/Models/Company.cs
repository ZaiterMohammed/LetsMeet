namespace LetsMeet.Abstractions.Models
{
	using System;

	public class Company
	{
		public Guid CompanyId
		{
			get;
			set;
		}

		public string CompanyName
		{
			get;
			set;
		}

		public CompanyTypes CompanyTypes
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
	}
}
