namespace LetsMeet.Abstractions.Models
{
    using System;

    public class PostAction
    {
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
    }
}
