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
        public IActionResult AddOffer([FromBody] CreateOfferRequest createOfferRequest)
        {
            return Ok(offerManager.AddOffer(createOfferRequest));
        }

        [HttpPut]
        [Route("api/offer")]
        public IActionResult UpdateOffer([FromBody] CreateOfferRequest createOfferRequest)
        {
            return Ok(offerManager.UpdateOffer(createOfferRequest));
        }

        [HttpDelete]
        [Route("api/offer/{offerId}")]
        public IActionResult DeleteOffer([FromRoute] Guid offerId)
        {
            return Ok(offerManager.DeleteOffer(offerId));
        }
    }
}
