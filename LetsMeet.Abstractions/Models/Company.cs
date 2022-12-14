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
