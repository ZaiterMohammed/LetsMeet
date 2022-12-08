namespace LetsMeet.WebApi.Controllers
{
    using LetsMeet.Abstractions.Managers;
    using LetsMeet.Abstractions.Models;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class PostController : Controller
    {
        private readonly IPostManager postManager;
        public PostController(IPostManager postManager)
        {
            this.postManager = postManager;
        }

        [HttpPost]
        [Route("api/post/like")]
        public IActionResult AddLike([FromBody] PostAction postAction)
        {
            return Ok(postManager.AddLike(postAction));
        }

        [HttpDelete]
        [Route("api/post/like/{postId}/{userId}")]
        public IActionResult DeleteLike([FromRoute] Guid postId, [FromRoute] Guid userId)
        {
            return Ok(postManager.DeleteLike(postId, userId));
        }
    }
}
