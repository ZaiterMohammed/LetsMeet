namespace LetsMeet.Abstractions.Models
{
	using System;

	public class CreatePostRequest
    {

		public string PostTitle
		{
			get;
			set;
		}

		public string PostDescription
		{
			get;
			set;
		}

        public Guid CreatedBy
        {
            get;
            set;
        }

        public Guid UpdatedBy
        {
            get;
            set;
        }

        public OwnerTypes OwnerTypes
        {
            get;
            set;
        }
    }
}
