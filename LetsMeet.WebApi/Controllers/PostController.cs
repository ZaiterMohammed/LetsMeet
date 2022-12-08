using LetsMeet.Abstractions.Managers;
using LetsMeet.Abstractions.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

namespace LetsMeet.WebApi.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostManager postManager;
        public PostController(IPostManager postManager)
        {
            this.postManager = postManager;
        }


        [HttpPost]
        [Route("api/post")]
        public IActionResult AddPost([FromBody] Post post) //post should be in CompanyController and OrganizationController
        {
            return Ok(postManager.AddPost(post));
        }

        [HttpPut]
        [Route("api/post")]
        public IActionResult UpdatePost([FromBody] Post post) //post should be in CompanyController and OrganizationController
        {
            return Ok(postManager.UpdatePost(post));
        }

        [HttpDelete]
        [Route("api/post/{postId}/{companyId}")] 
        public IActionResult DeletePost([FromRoute] Guid postId, Guid companyId) //post should be in CompanyController and OrganizationController
        {
            return Ok(postManager.DeletePost(postId, companyId));
        }


        [HttpPost]
        [Route("api/post")]
        public IActionResult AddLike([FromBody] PostAction postAction)
        {
            return Ok(postManager.AddLike(postAction));
        }

        [HttpDelete]
        [Route("api/post/{postActionId}")]
        public IActionResult DeleteLike([FromRoute] Guid postActionId)
        {
            return Ok(postManager.DeleteLike(postActionId));
        }
    }
}
