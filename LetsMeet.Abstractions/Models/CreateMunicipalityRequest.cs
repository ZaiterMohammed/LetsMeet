namespace LetsMeet.Abstractions.Models
{
    using System;

    public class CreateMunicipalityRequest
    {
        public Guid MunicipalityName
        {
            get;
            set;
        }

        public Guid CountryId
        {
            get;
            set;
        }
    }
}
