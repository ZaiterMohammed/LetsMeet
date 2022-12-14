namespace LetsMeet.Business
{
    using LetsMeet.Abstractions.Managers;
    using LetsMeet.Abstractions.Models;
    using LetsMeet.Abstractions.Store;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class OfferManager : IOfferManager
    {
        private readonly IOfferStore offerStore;

        public OfferManager(IOfferStore offerStore)
        {
            this.offerStore = offerStore;
        }

        public async Task<String> AddOffer(CreateOfferRequest createOfferRequest)
        {
            return await offerStore.AddOffer(createOfferRequest);
        }
        public async Task<String> UpdateOffer(CreateOfferRequest createOfferRequest)
        {
            return await offerStore.UpdateOffer(createOfferRequest);
        }
        public async Task<String> DeleteOffer(Guid offerId)
        {
            return await offerStore.DeleteOffer(offerId);
        }
        public async Task<List<Offer>> GetAllOfferByCreatedBy(Guid CreatedBy)
        {
            return await offerStore.GetAllOfferByCreatedBy(CreatedBy);
        }
    }
}
