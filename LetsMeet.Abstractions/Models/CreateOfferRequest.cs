namespace LetsMeet.Abstractions.Models
{
    using System;

    public class CreateOfferRequest
    {
        public string OfferTitle
        {
            get;
            set;
        }

        public OfferTypes OfferTypes
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