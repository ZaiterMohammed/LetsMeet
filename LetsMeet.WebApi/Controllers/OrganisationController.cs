namespace LetsMeet.WebApi.Controllers
{
    using LetsMeet.Abstractions.Managers;
    using LetsMeet.Abstractions.Models;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class OrganisationController : Controller
    {
        private readonly IOrganisationManager organisationManager;
        public OrganisationController(IOrganisationManager organisationManager)
        {
            this.organisationManager = organisationManager;
        }

        [HttpPost]
        [Route("api/organization")]
        public async Task<IActionResult> AddOrganisation([FromBody] CreateOrganisationRequest organisationRequest)
        {
            return Ok(await organisationManager.AddOrganisation(organisationRequest, 1));
        }

        [HttpPut]
        [Route("api/organization")]
        public async Task<IActionResult> UpdateOrganisation([FromBody] UpdateOrganisationRequest updateOrganisationRequest)
        {
            return Ok(await organisationManager.UpdateOrganisation(updateOrganisationRequest));
        }

        [HttpDelete]
        [Route("api/organization/{organizationId}")]
        public async Task<IActionResult> DeleteOrganisation([FromRoute] Guid organizationId)
        {
            return Ok(await organisationManager.DeleteOrganisation(organizationId));
        }

        [HttpPost]
        [Route("api/organization/{id}/users/{userId}/{roleName}")]
        public async Task<IActionResult> CreateRole([FromRoute] Guid id, [FromRoute] Guid userId, [FromRoute] string roleName)
        {
            return Ok(await organisationManager.CreateRole(id, userId, roleName));
        }

        [HttpPut]
        [Route("api/organization/{id}/users/{userId}/{roleName}")]
        public async Task<IActionResult> AcceptRole([FromRoute] Guid id, [FromRoute] Guid userId, [FromRoute] string roleName)
        {
            return Ok(await organisationManager.AcceptRole(id, userId, roleName));
        }


        [HttpDelete]
        [Route("api/organization/role/{roleId}")]
        public async Task<IActionResult> DeleteRole([FromRoute] Guid roleId)
        {
            return Ok(await organisationManager.DeleteRole(roleId));
        }

        [HttpPost]
        [Route("api/organization/post")]
        public async Task<IActionResult> AddPost([FromBody] CreatePostRequest createPostRequest)
        {
            return Ok(await organisationManager.AddPost(createPostRequest));
        }

        [HttpPut]
        [Route("api/organization/post")]
        public async Task<IActionResult> UpdatePost([FromBody] CreatePostRequest createPostRequest)
        {
            return Ok(await organisationManager.UpdatePost(createPostRequest));
        }

        [HttpDelete]
        [Route("api/organization/post/{postId}/{companyId}")]
        public async Task<IActionResult> DeletePost([FromRoute] Guid postId, [FromRoute] Guid companyId)
        {
            return Ok(await organisationManager.DeletePost(postId, companyId));
        }

        [HttpGet]
        [Route("api/organization/allOrganisation")]
        public async Task<IActionResult> GetAllOrganisation()
        {
            return Ok(await organisationManager.GetAllOrganisation());
        }

        [HttpGet]
        [Route("api/organization/allOrganisationNotVerified")]
        public async Task<IActionResult> GetAllOrganisationNotVerified()
        {
            return Ok(await organisationManager.GetAllOrganisationNotVerified());
        }

        [HttpGet]
        [Route("api/organization/allOrganisationVerified")]
        public async Task<IActionResult> GetAllOrganisationVerified()
        {
            return Ok(await organisationManager.GetAllOrganisationVerified());
        }
    }
}
