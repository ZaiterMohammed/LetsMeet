namespace LetsMeet.Abstractions.Models
{
    using System;

    public class Offer
    {
        public Guid OfferId
        {
            get;
            set;
        }

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

        public Guid ModifiedBy
        {
            get;
            set;
        }
    }
}