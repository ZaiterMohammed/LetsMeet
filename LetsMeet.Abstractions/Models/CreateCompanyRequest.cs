namespace LetsMeet.Abstractions.Models
{
	using System;

	public class CreateCompanyRequest
    {
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
	}
}
