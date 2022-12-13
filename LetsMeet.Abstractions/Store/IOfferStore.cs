namespace LetsMeet.Abstractions.Store
{
    using LetsMeet.Abstractions.Models;
    using System;
    using System.Collections.Generic;
    public interface IOfferStore
    {
        public string AddOffer(CreateOfferRequest createOfferRequest);
        public string UpdateOffer(CreateOfferRequest createOfferRequest);
        public string DeleteOffer(Guid offerId);
        public List<Offer> GetAllOfferByCreatedBy(Guid CreatedBy);
    }
}
