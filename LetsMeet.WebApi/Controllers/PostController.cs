namespace LetsMeet.WebApi.Controllers
{
    using LetsMeet.Abstractions.Managers;
    using LetsMeet.Abstractions.Models;
    using LetsMeet.WebApi.Redis;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json.Linq;

    [ApiController]
    public class PostController : Controller
    {
        private readonly IPostManager postManager;
        private readonly DbContextClass _dbContext;
        private readonly ICacheService _cacheService;
        public PostController(DbContextClass dbContext, ICacheService cacheService,IPostManager postManager)
        {
            _dbContext = dbContext;
            _cacheService = cacheService;
            this.postManager = postManager;
        }


        [HttpPost]
        [Route("api/post/like")]
        public async Task<IActionResult> AddLike([FromBody] PostAction postAction)
        {
            var obj = await _dbContext.PostAction.AddAsync(postAction);
            _cacheService.RemoveData("post");
            _dbContext.SaveChanges();
            return Ok(obj.Entity);

           // return Ok(await postManager.AddLike(postAction));
        }

        [HttpDelete]
        [Route("api/post/like/{postId}/{userId}")]
        public async Task<IActionResult> DeleteLike([FromRoute] Guid postId, [FromRoute] Guid userId)
        {
            return Ok(await postManager.DeleteLike(postId, userId));
        }
    }
}
