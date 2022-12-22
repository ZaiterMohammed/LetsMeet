
namespace LetsMeet.WebApi.Controllers
{
    using LetsMeet.Abstractions.Managers;
    using LetsMeet.Abstractions.Models;
    using Microsoft.AspNetCore.Mvc;

    public class MunicipalityController : Controller
    {
        private readonly IMunicipalityManager municipalityManager;

        public MunicipalityController(IMunicipalityManager municipalityManager)
        {
            this.municipalityManager = municipalityManager;
        }

        [HttpPost]
        [Route("api/municipalities")]
        public async Task<IActionResult> CreateMunicipality([FromBody] CreateMunicipalityRequest createMunicipalityRequest)
        {
            return Ok( await municipalityManager.CreateMunicipality(createMunicipalityRequest));
        }

        [HttpPut]
        [Route("api/municipalities")]
        public async Task<IActionResult> UpdateMunicipality([FromBody] Municipality municipality)
        {
            return Ok( await municipalityManager.UpdateMunicipality(municipality));
        }

        [HttpDelete]
        [Route("api/municipalities/{municipalityId}")]
        public async Task<IActionResult> DeleteMunicipality([FromRoute] Guid municipalityId)
        {
            return Ok(await municipalityManager.DeleteMunicipality(municipalityId));
        }

        [HttpGet]
        [Route("api/municipalities")]
        public async Task<IActionResult> GetAllMunicipalities()
        {
            return Ok(await municipalityManager.GetAllMunicipality());
        }

        [HttpPost]
        [Route("api/municipalities/{municipalityId}/admin/{adminId}")]
        [ProducesResponseType(200, Type =typeof(void))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AssignAdmin([FromRoute]string municipalityId,[FromRoute] string adminId)
        {
            if (string.IsNullOrEmpty(municipalityId))
            {
                this.ModelState.AddModelError("MunicipalityIdCannotBeNull", "Municipality id cannot be null or empty string.");

                return BadRequest(this.ModelState);
            }

            return Ok(await municipalityManager.AddAdmin(createAdminRequest));
        }
        
        [HttpDelete]
        [Route("api/municipalities/{municipalityId}/admin/{adminId}")]
        public async Task<IActionResult> RemoveAdmin([FromRoute] Guid adminId , [FromRoute] Guid userId, [FromRoute] Guid municipalityId)
        {
            return Ok( await municipalityManager.DeleteAdmin(adminId, userId, municipalityId));
        }

        [HttpGet]
        [Route("api/municipalities/{municipalityId}")]
        [ProducesResponseType(200,Type = typeof(Municipality))]
        public async Task<IActionResult> GetMunicipalityById([FromRoute] Guid municipalityId)
        {
            return Ok(await municipalityManager.GetMunicipalityById(municipalityId));
        }
    }
}
