using LetsMeet.Abstractions.Managers;
using LetsMeet.Abstractions.Models;
using Microsoft.AspNetCore.Mvc;

namespace LetsMeet.WebApi.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyManager companyManager;
        public CompanyController(ICompanyManager companyManager)
        {
            this.companyManager = companyManager;
        }


        [HttpPost]
        [Route("api/company")]
        public IActionResult AddCompany([FromBody] Company company)
        {
            return Ok(companyManager.AddCompany(company));
        }

        [HttpPut]
        [Route("api/company")]
        public IActionResult UpdateCompany([FromBody] Company company)
        {
            return Ok(companyManager.UpdateCompany(company));
        }

        [HttpDelete]
        [Route("api/company/{companyId}")]
        public IActionResult DeleteCompany([FromRoute] Guid companyId)
        {
            return Ok(companyManager.DeleteCompany(companyId));
        }


        [HttpPost]
        [Route("api/company")]
        public IActionResult CreateRole([FromBody] Role role)
        {
            return Ok(companyManager.CreateRole(role));
        }

        [HttpPut]
        [Route("api/company")]
        public IActionResult AcceptRole([FromBody] Role role)
        {
            return Ok(companyManager.AcceptRole(role));
        }

        [HttpDelete]
        [Route("api/company/{roleId}")]
        public IActionResult DeleteRole([FromRoute] Guid roleId)
        {
            return Ok(companyManager.DeleteRole(roleId));
        }
    }
}
