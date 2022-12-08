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
        public IActionResult AddOrganisation([FromBody] CreateOrganisationRequest organisationRequest)
        {
            return Ok(organisationManager.AddOrganisation(organisationRequest));
        }

        [HttpPut]
        [Route("api/organization")]
        public IActionResult UpdateOrganisation([FromBody] CreateOrganisationRequest organisationRequest)
        {
            return Ok(organisationManager.UpdateOrganisation(organisationRequest));
        }

        [HttpDelete]
        [Route("api/organization/{organizationId}")]
        public IActionResult DeleteOrganisation([FromRoute] Guid organizationId)
        {
            return Ok(organisationManager.DeleteOrganisation(organizationId));
        }

        [HttpPost]
        [Route("api/organization/{id}/users/{userId}/{roleName}")]
        public IActionResult CreateRole([FromRoute] Guid id, [FromRoute] Guid userId, [FromRoute] string roleName)
        {
            return Ok(organisationManager.CreateRole(id, userId, roleName));
        }

        [HttpPut]
        [Route("api/organization/{id}/users/{userId}/{roleName}")]
        public IActionResult AcceptRole([FromRoute] Guid id, [FromRoute] Guid userId, [FromRoute] string roleName)
        {
            return Ok(organisationManager.AcceptRole(id, userId, roleName));
        }


        [HttpDelete]
        [Route("api/organization/role/{roleId}")]
        public IActionResult DeleteRole([FromRoute] Guid roleId)
        {
            return Ok(organisationManager.DeleteRole(roleId));
        }

        [HttpPost]
        [Route("api/organization/post")]
        public IActionResult AddPost([FromBody] CreatePostRequest createPostRequest)
        {
            return Ok(organisationManager.AddPost(createPostRequest));
        }

        [HttpPut]
        [Route("api/organization/post")]
        public IActionResult UpdatePost([FromBody] CreatePostRequest createPostRequest)
        {
            return Ok(organisationManager.UpdatePost(createPostRequest));
        }

        [HttpDelete]
        [Route("api/organization/post/{postId}/{companyId}")]
        public IActionResult DeletePost([FromRoute] Guid postId, [FromRoute] Guid companyId)
        {
            return Ok(organisationManager.DeletePost(postId, companyId));
        }

    }
}
