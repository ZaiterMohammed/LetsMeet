namespace LetsMeet.WebApi.Controllers
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
        public async Task<IActionResult> AddCompany([FromBody] CreateCompanyRequest createCompanyRequest)
        {
            return Ok(await companyManager.AddCompany(createCompanyRequest));
        }

       
       [HttpPut]
       [Route("api/company")]
       public async Task<IActionResult> UpdateCompany([FromBody] CreateCompanyRequest createCompanyRequest)
       {
           return Ok(await companyManager.UpdateCompany(createCompanyRequest));
       }
        
        [HttpDelete]
        [Route("api/company/{companyId}")]
        public async Task<IActionResult> DeleteCompany([FromRoute] Guid companyId)
        {
            return Ok(await companyManager.DeleteCompany(companyId));
        }


        [HttpPost]
        [Route("api/company/{id}/users/{userId}/{roleName}")]
        public async Task<IActionResult> CreateRole([FromRoute] Guid id, [FromRoute] Guid userId, [FromRoute] string roleName)
        {
            return Ok(await companyManager.CreateRole(id, userId, roleName));
        }

        [HttpPut]
        [Route("api/company/{id}/users/{userId}/{roleName}")]
        public async Task<IActionResult> AcceptRole([FromRoute] Guid id, [FromRoute] Guid userId, [FromRoute] string roleName)
        {
            return Ok(await companyManager.AcceptRole(id, userId, roleName));
        }


        [HttpDelete]
        [Route("api/company/role/{roleId}")]
        public async Task<IActionResult> DeleteRole([FromRoute] Guid roleId)
        {
            return Ok(await companyManager.DeleteRole(roleId));
        }


        [HttpPost]
        [Route("api/company/post")]
        public async Task<IActionResult> AddPost([FromBody] CreatePostRequest createPostRequest) //post should be in CompanyController and OrganizationController
        {
            return Ok( await companyManager.AddPost(createPostRequest));
        }

        [HttpPut]
        [Route("api/company/post")]
        public async Task<IActionResult> UpdatePost([FromBody] CreatePostRequest createPostRequest) //post should be in CompanyController and OrganizationController
        {
            return Ok(await companyManager.UpdatePost(createPostRequest));
        }

        [HttpDelete]
        [Route("api/company/post/{postId}/{companyId}")]
        public async Task<IActionResult> DeletePost([FromRoute] Guid postId, [FromRoute] Guid companyId) //post should be in CompanyController and OrganizationController
        {
            return Ok( await companyManager.DeletePost(postId, companyId));
        }

    }
}
