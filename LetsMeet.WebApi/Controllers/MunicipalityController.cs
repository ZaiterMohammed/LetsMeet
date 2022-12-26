
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
        [ProducesResponseType(200, Type = typeof(Guid))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateMunicipality([FromBody] CreateMunicipalityRequest createMunicipalityRequest)
        {
            if (createMunicipalityRequest == null)
            {
                this.ModelState.AddModelError("CreateMunicipalityCannotBeNull", "Create Municipality cannot be null.");

                return BadRequest(this.ModelState);
            }
            return Ok( await municipalityManager.CreateMunicipality(createMunicipalityRequest));
        }

        [HttpPut]
        [Route("api/municipalities")]
        [ProducesResponseType(200, Type = typeof(Guid))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateMunicipality([FromBody] Municipality municipality)
        {
            if (municipality == null)
            {
                this.ModelState.AddModelError("MunicipalityCannotBeNull", "Municipality cannot be null.");

                return BadRequest(this.ModelState);
            }
            return Ok( await municipalityManager.UpdateMunicipality(municipality));
        }

        [HttpDelete]
        [Route("api/municipalities/{municipalityId}")]
        [ProducesResponseType(200, Type = typeof(Guid))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> RemoveMunicipality([FromRoute] Guid municipalityId)
        {
            if (municipalityId == Guid.Empty)
            {
                this.ModelState.AddModelError("MunicipalityIdCannotBeNull", "MunicipalityId cannot be null.");

                return BadRequest(this.ModelState);
            }
            return Ok(await municipalityManager.RemoveMunicipality(municipalityId));
        }

        [HttpGet]
        [Route("api/municipalities")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Municipality>))]
        public async Task<IActionResult> GetAllMunicipalities()
        {
            return Ok(await municipalityManager.GetAllMunicipality());
        }

        [HttpPost]
        [Route("api/municipalities/{municipalityId}/admin/{userId}")]
        [ProducesResponseType(200, Type =typeof(Guid))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AssignAdmin([FromRoute]Guid municipalityId,[FromRoute] Guid userId)
        {
            if (municipalityId == Guid.Empty)
            {
                this.ModelState.AddModelError("MunicipalityIdCannotBeEmpty", "Municipality id cannot be empty.");

                return BadRequest(this.ModelState);
            }
            if (userId == Guid.Empty)
            {
                this.ModelState.AddModelError("UserIdCannotBeEmpty", "user id cannot be empty.");

                return BadRequest(this.ModelState);
            }

            return Ok(await municipalityManager.AssignAdmin(municipalityId,userId));
        }
        
        [HttpDelete]
        [Route("api/municipalities/{municipalityId}/admin/{adminId}")]
        [ProducesResponseType(200, Type = typeof(Guid))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> RemoveAdmin([FromRoute] Guid adminId , [FromRoute] Guid userId, [FromRoute] Guid municipalityId)
        {
            if (adminId == Guid.Empty)
            {
                this.ModelState.AddModelError("AdminIdCannotBeEmpty", "admin id cannot be empty.");

                return BadRequest(this.ModelState);
            }
            if (userId == Guid.Empty)
            {
                this.ModelState.AddModelError("UserIdCannotBeEmpty", "user id cannot be empty.");

                return BadRequest(this.ModelState);
            }
            if (municipalityId == Guid.Empty)
            {
                this.ModelState.AddModelError("MunicipalityIdCannotBeEmpty", "municipality id cannot be empty.");

                return BadRequest(this.ModelState);
            }
            return Ok( await municipalityManager.RemoveAdmin(adminId, userId, municipalityId));
        }

        [HttpGet]
        [Route("api/municipalities/{municipalityId}")]
        [ProducesResponseType(200,Type = typeof(Municipality))]
        public async Task<IActionResult> GetMunicipalityById([FromRoute] Guid municipalityId)
        {
            if (municipalityId == Guid.Empty)
            {
                this.ModelState.AddModelError("MunicipalityIdCannotBeEmpty", "municipality id cannot be empty.");

                return BadRequest(this.ModelState);
            }
            return Ok(await municipalityManager.GetMunicipalityById(municipalityId));
        }
    }
}
