using LetsMeet.Abstractions.Managers;
using LetsMeet.Abstractions.Models;
using Microsoft.AspNetCore.Mvc;

namespace LetsMeet.WebApi.Controllers
{
    public class MunicipalityController : Controller
    {
        private readonly IMunicipalityManager municipalityManager;
        public MunicipalityController(IMunicipalityManager municipalityManager)
        {
            this.municipalityManager = municipalityManager;
        }

        [HttpPost]
        [Route("api/municipality")]
        public async Task<IActionResult> AddMunicipality([FromBody] CreateMunicipalityRequest createMunicipalityRequest)
        {
            return Ok( await municipalityManager.AddMunicipality(createMunicipalityRequest));
        }

        [HttpPut]
        [Route("api/municipality")]
        public async Task<IActionResult> UpdateMunicipality([FromBody] Municipality municipality)
        {
            return Ok( await municipalityManager.UpdateMunicipality(municipality));
        }

        [HttpDelete]
        [Route("api/municipality/{municipalityId}")]
        public async Task<IActionResult> DeleteMunicipality([FromRoute] Guid municipalityId)
        {
            return Ok(await municipalityManager.DeleteMunicipality(municipalityId));
        }

        [HttpGet]
        [Route("api/municipality")]
        public async Task<IActionResult> GetAllMunicipality()
        {
            return Ok(await municipalityManager.GetAllMunicipality());
        }

        [HttpPost]
        [Route("api/admin")]
        public async Task<IActionResult> AddAdmin([FromBody] CreateAdminRequest createAdminRequest)
        {
            return Ok(await municipalityManager.AddAdmin(createAdminRequest));
        }
        
        [HttpDelete]
        [Route("api/admin/{adminId}/user/{userId}/municipality/{municipalityId}")]
        public async Task<IActionResult> DeleteAdmin([FromRoute] Guid adminId , [FromRoute] Guid userId, [FromRoute] Guid municipalityId)
        {
            return Ok( await municipalityManager.DeleteAdmin(adminId, userId, municipalityId));
        }

        [HttpGet]
        [Route("api/municipality/{municipalityId}")]
        public async Task<IActionResult> GetAllMunicipality([FromRoute] Guid municipalityId)
        {
            return Ok(await municipalityManager.GetMunicipalityById(municipalityId));
        }
    }
}
