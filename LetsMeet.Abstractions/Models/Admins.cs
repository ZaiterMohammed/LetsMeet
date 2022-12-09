namespace LetsMeet.Abstractions.Models
{
    using System;

    public class Admins
    {
        public Guid AdminId
        {
            get;
            set;
        }

        public Guid UserId
        {
            get;
            set;
        }

        public Guid MunicipalityId
        {
            get;
            set;
        }
    }
}
