namespace LetsMeet.Abstractions.Managers
{
    using LetsMeet.Abstractions.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IOfferManager
    {
        public Task<String> AddOffer(CreateOfferRequest createOfferRequest);
        public Task<String> UpdateOffer(CreateOfferRequest createOfferRequest);
        public Task<String> DeleteOffer(Guid offerId);
        public Task<List<Offer>> GetAllOfferByCreatedBy(Guid CreatedBy);
    }
}
