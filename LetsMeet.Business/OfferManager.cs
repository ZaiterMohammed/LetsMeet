namespace LetsMeet.Business
{
    using LetsMeet.Abstractions.Managers;
    using LetsMeet.Abstractions.Models;
    using LetsMeet.Abstractions.Store;
    using System;
    using System.Collections.Generic;

    public class OfferManager : IOfferManager
    {
        private readonly IOfferStore offerStore;

        public OfferManager(IOfferStore offerStore)
        {
            this.offerStore = offerStore;
        }

        public string AddOffer(CreateOfferRequest createOfferRequest)
        {
            return offerStore.AddOffer(createOfferRequest);
        }
        public string UpdateOffer(CreateOfferRequest createOfferRequest)
        {
            return offerStore.UpdateOffer(createOfferRequest);
        }
        public string DeleteOffer(Guid offerId)
        {
            return offerStore.DeleteOffer(offerId);
        }
        public List<Offer> GetAllOfferByCreatedBy(Guid CreatedBy)
        {
            return offerStore.GetAllOfferByCreatedBy(CreatedBy);
        }
    }
}
