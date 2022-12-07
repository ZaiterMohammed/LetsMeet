namespace LetsMeet.Abstractions.Models
{
	using System;
	using LetsMeet.Abstractions.Models;

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
