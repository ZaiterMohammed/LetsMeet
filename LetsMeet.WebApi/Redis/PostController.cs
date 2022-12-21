
namespace LetsMeet.WebApi.Redis
{
    using LetsMeet.Abstractions.Models;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DbContextClass _dbContext;
        private readonly ICacheService _cacheService;
        public ProductController(DbContextClass dbContext, ICacheService cacheService)
        {
            _dbContext = dbContext;
            _cacheService = cacheService;
        }

        [HttpGet("postsaction")]
        public IEnumerable<PostAction> GetLikes()
        {
            var cacheData = _cacheService.GetData<IEnumerable<PostAction>>("postaction");
            if (cacheData != null)
            {
                return cacheData;
            }
            var expirationTime = DateTimeOffset.Now.AddMinutes(5.0);
            cacheData = _dbContext.PostAction.ToList();
            _cacheService.SetData<IEnumerable<PostAction>>("postaction", cacheData, expirationTime);
            return cacheData;
        }
        [HttpGet("postaction")]
        public PostAction GetPostById(Guid id)
        {
            PostAction filteredData;
            var cacheData = _cacheService.GetData<IEnumerable<PostAction>>("postaction");
            if (cacheData != null)
            {
                filteredData = cacheData.Where(x => x.PostId == id).FirstOrDefault();
                return filteredData;
            }
            filteredData = _dbContext.PostAction.Where(x => x.PostId == id).FirstOrDefault();
            return filteredData;
        }


        [HttpPost("addpostaction")]
        public async Task<PostAction> Post(PostAction value)
        {
            var obj = await _dbContext.PostAction.AddAsync(value);
            _cacheService.RemoveData("postaction");
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        [HttpPut("updatepostaction")]
        public void Put(PostAction post)
        {
            _dbContext.PostAction.Update(post);
            _cacheService.RemoveData("postaction");
            _dbContext.SaveChanges();
        }

        [HttpDelete("deletepostaction")]
        public void Delete(Guid Id)
        {
            var filteredData = _dbContext.PostAction.Where(x => x.PostId == Id).FirstOrDefault();
            _dbContext.Remove(filteredData);
            _cacheService.RemoveData("postaction");
            _dbContext.SaveChanges();
        }
    }
}