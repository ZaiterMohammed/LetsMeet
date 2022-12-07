namespace LetsMeet.Abstractions.Models
{
    using System;

    public class PostAction
    {
        public Guid PostActionId
        {
            get;
            set;
        }
        public Guid PostId
        {
            get;
            set;
        }

        public Guid UserId
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

        public int Like
        {
            get;
            set;
        }

    }
}
