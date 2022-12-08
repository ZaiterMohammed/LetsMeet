namespace LetsMeet.Abstractions.Models
{
	using System;

	public class CreateOrganisationRequest
    {
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
	}
}
