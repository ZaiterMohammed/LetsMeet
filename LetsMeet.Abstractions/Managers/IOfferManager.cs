namespace LetsMeet.Abstractions.Managers
{
    using LetsMeet.Abstractions.Models;
    using System;
    using System.Collections.Generic;

    public interface IOfferManager
    {
        public string AddOffer(CreateOfferRequest createOfferRequest);
        public string UpdateOffer(CreateOfferRequest createOfferRequest);
        public string DeleteOffer(Guid offerId);
        public List<Offer> GetAllOfferByCreatedBy(Guid CreatedBy);
    }
}
