namespace LetsMeet.WebApi.Controllers
{
    using LetsMeet.Abstractions.Managers;
    using LetsMeet.Abstractions.Models;
    using LetsMeet.Business;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class OfferController : Controller
    {
        private readonly IOfferManager offerManager;
        public OfferController(IOfferManager offerManager)
        {
            this.offerManager = offerManager;
        }

        [HttpPost]
        [Route("api/offer")]
        public async Task<IActionResult> AddOffer([FromBody] CreateOfferRequest createOfferRequest)
        {
            return Ok(await offerManager.AddOffer(createOfferRequest));
        }

        [HttpPut]
        [Route("api/offer")]
        public async Task<IActionResult> UpdateOffer([FromBody] CreateOfferRequest createOfferRequest)
        {
            return Ok(await offerManager.UpdateOffer(createOfferRequest));
        }

        [HttpDelete]
        [Route("api/offer/{offerId}")]
        public async Task<IActionResult> DeleteOffer([FromRoute] Guid offerId)
        {
            return Ok(await offerManager.DeleteOffer(offerId));
        }
    }
}
