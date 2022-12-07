using LetsMeet.Abstractions.Managers;
using LetsMeet.Abstractions.Models;
using Microsoft.AspNetCore.Mvc;

namespace LetsMeet.WebApi.Controllers
{
    public class OrganisationController : Controller
    {
        private readonly IOrganisationManager organisationManager;
        public OrganisationController(IOrganisationManager organisationManager)
        {
            this.organisationManager = organisationManager;
        }


        [HttpPost]
        [Route("api/organization")]
        public IActionResult AddOrganisation([FromBody] Organisation organisation)
        {
            return Ok(organisationManager.AddOrganisation(organisation));
        }

        [HttpPut]
        [Route("api/organization")]
        public IActionResult UpdateOrganisation([FromBody] Organisation organisation)
        {
            return Ok(organisationManager.UpdateOrganisation(organisation));
        }

        [HttpDelete]
        [Route("api/organization/{organisationId}")]
        public IActionResult DeleteOrganisation([FromRoute] Guid organizationId)
        {
            return Ok(organisationManager.DeleteOrganisation(organizationId));
        }


        [HttpPost]
        [Route("api/organization")]
        public IActionResult CreateRole([FromBody] Role role)
        {
            return Ok(organisationManager.CreateRole(role));
        }

        [HttpPut]
        [Route("api/organization")]
        public IActionResult AcceptRole([FromBody] Role role)
        {
            return Ok(organisationManager.AcceptRole(role));
        }

        [HttpDelete]
        [Route("api/organization/{roleId}")]
        public IActionResult DeleteRole([FromRoute] Guid roleId)
        {
            return Ok(organisationManager.DeleteRole(roleId));
        }
    }
}
