namespace LetsMeet.Abstractions.Models
{
	using System;
	using System.ComponentModel;

	public class Organisation
	{
		public Guid OrganisationId
		{ 
			get;
			set;
		}

		public string OrganisationName
        {
			get;
			set;
		}

		public OrganisationTypes OrganisationTypes
		{
			get;
			set;
		}

		public OrganisationCategory OrganisationCategory
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
