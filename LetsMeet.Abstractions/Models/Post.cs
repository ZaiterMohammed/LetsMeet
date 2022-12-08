namespace LetsMeet.Abstractions.Models
{
	using System;

	public class Post
	{
		public Guid PostId
		{
			get;
			set;
		}

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
