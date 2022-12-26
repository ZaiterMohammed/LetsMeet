namespace LetsMeet.WebApi.Controllers
{
    using LetsMeet.Abstractions.Managers;
    using LetsMeet.Abstractions.Models;
    using Microsoft.AspNetCore.Mvc;
    using StackExchange.Redis;

    [ApiController]
    public class OrganisationController : Controller
    {
        private readonly IOrganisationManager organisationManager;
        public OrganisationController(IOrganisationManager organisationManager)
        {
            this.organisationManager = organisationManager;
        }

        [HttpPost]
        [Route("api/organizations")]
        [ProducesResponseType(200, Type = typeof(Guid))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateOrganisation([FromBody] CreateOrganisationRequest organisationRequest)
        {
            if (organisationRequest == null)
            {
                this.ModelState.AddModelError("CreateOrganisationRequestRequestCannotBeNull", "CreateOrganisationRequest cannot be null.");

                return BadRequest(this.ModelState);
            }
            return Ok(await organisationManager.CreateOrganisation(organisationRequest, 1));
        }

        [HttpPut]
        [Route("api/organizations")]
        [ProducesResponseType(200, Type = typeof(Guid))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateOrganisation([FromBody] UpdateOrganisationRequest updateOrganisationRequest)
        {
            if (updateOrganisationRequest == null)
            {
                this.ModelState.AddModelError("UpdateOrganisationRequestRequestCannotBeNull", "UpdateOrganisationRequest cannot be null.");

                return BadRequest(this.ModelState);
            }
            return Ok(await organisationManager.UpdateOrganisation(updateOrganisationRequest));
        }

        [HttpDelete]
        [Route("api/organizations/{organizationId}")]
        [ProducesResponseType(200, Type = typeof(Guid))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> RemoveOrganisation([FromRoute] Guid organizationId)
        {
            if (organizationId == Guid.Empty)
            {
                this.ModelState.AddModelError("OrganizationIdRequestCannotBeNull", "Organisation Id cannot be null.");

                return BadRequest(this.ModelState);
            }
            return Ok(await organisationManager.RemoveOrganisation(organizationId));
        }

        [HttpPost]
        [Route("api/organizations/{id}/users/{userId}/role/{roleName}")]
        [ProducesResponseType(200, Type = typeof(Guid))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateRole([FromRoute] Guid id, [FromRoute] Guid userId, [FromRoute] string roleName)
        {
            if (id == Guid.Empty)
            {
                this.ModelState.AddModelError("IdRequestCannotBeNull", "Id cannot be null.");

                return BadRequest(this.ModelState);
            }
            if (userId == Guid.Empty)
            {
                this.ModelState.AddModelError("UserIdRequestCannotBeNull", "User Id cannot be null.");

                return BadRequest(this.ModelState);
            }
            if (userId == null)
            {
                this.ModelState.AddModelError("RoleNameRequestCannotBeNull", "Role Name cannot be null.");

                return BadRequest(this.ModelState);
            }
            return Ok(await organisationManager.CreateRole(id, userId, roleName));
        }

        [HttpPut]
        [Route("api/organizations/{id}/users/{userId}/role/{roleName}")]
        [ProducesResponseType(200, Type = typeof(Guid))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AcceptRole([FromRoute] Guid id, [FromRoute] Guid userId, [FromRoute] string roleName)
        {
            if (id == Guid.Empty)
            {
                this.ModelState.AddModelError("IdRequestCannotBeNull", "Id cannot be null.");

                return BadRequest(this.ModelState);
            }
            if (userId == Guid.Empty)
            {
                this.ModelState.AddModelError("UserIdRequestCannotBeNull", "User Id cannot be null.");

                return BadRequest(this.ModelState);
            }
            if (userId == null)
            {
                this.ModelState.AddModelError("RoleNameRequestCannotBeNull", "Role Name cannot be null.");

                return BadRequest(this.ModelState);
            }
            return Ok(await organisationManager.AcceptRole(id, userId, roleName));
        }


        [HttpDelete]
        [Route("api/organizations/role/{roleId}")]
        [ProducesResponseType(200, Type = typeof(Guid))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> RemoveRole([FromRoute] Guid roleId)
        {
            if (roleId == Guid.Empty)
            {
                this.ModelState.AddModelError("RoleIdRequestCannotBeNull", "Role Id cannot be null.");

                return BadRequest(this.ModelState);
            }
            else
            {
                return Ok(await organisationManager.RemoveRole(roleId));
            }
        }

        [HttpPost]
        [Route("api/organizations/post")]
        [ProducesResponseType(200, Type = typeof(Guid))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostRequest createPostRequest)
        {
            if (createPostRequest == null)
            {
                this.ModelState.AddModelError("CreatePostRequestCannotBeNull", "CreateCompanyRequest cannot be null.");

                return BadRequest(this.ModelState);
            }
            return Ok(await organisationManager.CreatePost(createPostRequest));
        }

        [HttpPut]
        [Route("api/organizations/post")]
        [ProducesResponseType(200, Type = typeof(Guid))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdatePost([FromBody] CreatePostRequest createPostRequest)
        {
            if (createPostRequest == null)
            {
                this.ModelState.AddModelError("CreatePostRequestCannotBeNull", "CreateCompanyRequest cannot be null.");

                return BadRequest(this.ModelState);
            }

            return Ok(await organisationManager.UpdatePost(createPostRequest));
        }

        [HttpDelete]
        [Route("api/organizations/post/{postId}/company/{companyId}")]
        [ProducesResponseType(200, Type = typeof(Guid))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> RemovePost([FromRoute] Guid postId, [FromRoute] Guid companyId)
        {
            if (postId == Guid.Empty)
            {
                this.ModelState.AddModelError("PostIdCannotBeNull", "Post Id cannot be null.");

                return BadRequest(this.ModelState);
            }
            if (companyId == Guid.Empty)
            {
                this.ModelState.AddModelError("CompanyIdCannotBeNull", "Company Id cannot be null.");

                return BadRequest(this.ModelState);
            }

            return Ok(await organisationManager.RemovePost(postId, companyId));
        }

        [HttpGet]
        [Route("api/organizations/allOrganisation")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Organisation>))]
        public async Task<IActionResult> GetAllOrganisation()
        {
            return Ok(await organisationManager.GetAllOrganisation());
        }

        [HttpGet]
        [Route("api/organizations/allOrganisationNotVerified")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Organisation>))]

        public async Task<IActionResult> GetAllOrganisationNotVerified()
        {
            return Ok(await organisationManager.GetAllOrganisationNotVerified());
        }

        [HttpGet]
        [Route("api/organizations/allOrganisationVerified")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Organisation>))]

        public async Task<IActionResult> GetAllOrganisationVerified()
        {
            return Ok(await organisationManager.GetAllOrganisationVerified());
        }
    }
}
