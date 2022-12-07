using LetsMeet.Abstractions.Managers;
using LetsMeet.Abstractions.Models;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult AddPost([FromBody] Post post)
        {
            return Ok(postManager.AddPost(post));
        }

        [HttpPut]
        [Route("api/post")]
        public IActionResult UpdatePost([FromBody] Post post)
        {
            return Ok(postManager.UpdatePost(post));
        }

        [HttpDelete]
        [Route("api/post/{postId}")]
        public IActionResult DeletePost([FromRoute] Guid postId)
        {
            return Ok(postManager.DeletePost(postId));
        }

    }
}
