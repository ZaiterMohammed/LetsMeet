﻿namespace LetsMeet.WebApi.Controllers
{
    using LetsMeet.Abstractions.Managers;
    using LetsMeet.Abstractions.Models;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
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
        [Route("api/company/{id}/users/{userId}/{roleName}")]
        public IActionResult CreateRole([FromRoute] Guid id, [FromRoute] Guid userId, [FromRoute] string roleName)
        {
            return Ok(companyManager.CreateRole(id, userId, roleName));
        }

        [HttpPut]
        [Route("api/company/{id}/users/{userId}/{roleName}")]
        public IActionResult AcceptRole([FromRoute] Guid id, [FromRoute] Guid userId, [FromRoute] string roleName)
        {
            return Ok(companyManager.AcceptRole(id, userId, roleName));
        }


        [HttpDelete]
        [Route("api/company/role/{roleId}")]
        public IActionResult DeleteRole([FromRoute] Guid roleId)
        {
            return Ok(companyManager.DeleteRole(roleId));
        }


        [HttpPost]
        [Route("api/company/post")]
        public IActionResult AddPost([FromBody] Post post) //post should be in CompanyController and OrganizationController
        {
            return Ok(companyManager.AddPost(post));
        }

        [HttpPut]
        [Route("api/company/post")]
        public IActionResult UpdatePost([FromBody] Post post) //post should be in CompanyController and OrganizationController
        {
            return Ok(companyManager.UpdatePost(post));
        }

        [HttpDelete]
        [Route("api/company/post/{postId}/{companyId}")]
        public IActionResult DeletePost([FromRoute] Guid postId, [FromRoute] Guid companyId) //post should be in CompanyController and OrganizationController
        {
            return Ok(companyManager.DeletePost(postId, companyId));
        }

    }
}
