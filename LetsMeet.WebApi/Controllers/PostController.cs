namespace LetsMeet.WebApi.Controllers
{
    using LetsMeet.Abstractions.Managers;
    using LetsMeet.Abstractions.Models;
    using LetsMeet.WebApi;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json.Linq;

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
        [ProducesResponseType(200, Type = typeof(Guid))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddLike([FromBody] PostAction postAction)
        {
            if (postAction == null)
            {
                this.ModelState.AddModelError("PostActionCannotBeNull", "Post Action cannot be null.");

                return BadRequest(this.ModelState);
            }

            return Ok(await postManager.AddLike(postAction));
        }

        [HttpDelete]
        [Route("api/post/like/{postId}/user/{userId}")]
        [ProducesResponseType(200, Type = typeof(Guid))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> RemoveLike([FromRoute] Guid postId, [FromRoute] Guid userId)
        {
            if (postId == Guid.Empty)
            {
                this.ModelState.AddModelError("PostIdCannotBeNull", "Post Id cannot be null.");

                return BadRequest(this.ModelState);
            }
            if (userId == Guid.Empty)
            {
                this.ModelState.AddModelError("UserIdCannotBeNull", "User Id cannot be null.");

                return BadRequest(this.ModelState);
            }
            return Ok(await postManager.RemoveLike(postId, userId));
        }
    }
}
