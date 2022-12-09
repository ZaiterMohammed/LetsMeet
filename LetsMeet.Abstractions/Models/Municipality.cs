namespace LetsMeet.Abstractions.Models
{
    using System;

    public class Municipality
    {
        public Guid MunicipalityId { 
            get;
            set; 
        }

        public string MunicipalityName
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
