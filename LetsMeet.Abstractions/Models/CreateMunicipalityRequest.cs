﻿namespace LetsMeet.Abstractions.Models
{
    using System;

    public class CreateMunicipalityRequest
    {
        public string Name
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
