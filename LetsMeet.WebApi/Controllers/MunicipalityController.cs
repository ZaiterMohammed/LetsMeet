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
        public IActionResult AddMunicipality([FromBody] CreateMunicipalityRequest createMunicipalityRequest)
        {
            return Ok(municipalityManager.AddMunicipality(createMunicipalityRequest));
        }

        [HttpPut]
        [Route("api/municipality")]
        public IActionResult UpdateMunicipality([FromBody] Municipality municipality)
        {
            return Ok(municipalityManager.UpdateMunicipality(municipality));
        }

        [HttpDelete]
        [Route("api/municipality/{municipalityId}")]
        public IActionResult DeleteMunicipality([FromRoute] Guid municipalityId)
        {
            return Ok(municipalityManager.DeleteMunicipality(municipalityId));
        }

        [HttpGet]
        [Route("api/municipality")]
        public IActionResult GetAllMunicipality()
        {
            return Ok(municipalityManager.GetAllMunicipality());
        }

        [HttpPost]
        [Route("api/admin")]
        public IActionResult AddAdmin([FromBody] CreateAdminRequest createAdminRequest)
        {
            return Ok(municipalityManager.AddAdmin(createAdminRequest));
        }
        
        [HttpDelete]
        [Route("api/admin/{adminId}/user/{userId}/municipality/{municipalityId}")]
        public IActionResult DeleteAdmin([FromRoute] Guid adminId , [FromRoute] Guid userId, [FromRoute] Guid municipalityId)
        {
            return Ok(municipalityManager.DeleteAdmin(adminId, userId, municipalityId));
        }
    }
}
