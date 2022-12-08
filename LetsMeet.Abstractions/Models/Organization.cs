namespace LetsMeet.Abstractions.Models
{
	using System;
	using System.ComponentModel;

	public class Organization
	{
		public Guid OrganizationId

		{ get; set; }

		public string Name

		{
			get;
			set;
		}

		public OrganizationType OrganizationType

		{
			get;
			set;
		}

		public OrganizationCategory Category

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
