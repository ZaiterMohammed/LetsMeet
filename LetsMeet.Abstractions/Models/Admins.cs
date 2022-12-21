namespace LetsMeet.Abstractions.Models
{
    using System;

    public class Admins
    {
        //[Range(0,1000)]
       // [Required]
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
