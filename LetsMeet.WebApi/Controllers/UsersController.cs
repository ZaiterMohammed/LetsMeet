namespace LetsMeet.WebApi.Controllers
{
    using LetsMeet.Abstractions.Managers;
    using LetsMeet.Abstractions.Models;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserManager userManager;

        public UsersController(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost]
        [Route("api/users")]
        public IActionResult AddUser([FromBody] CreateRequestUser createRequestUser)
        {
            return Ok(userManager.AddUser(createRequestUser));
        }

        [HttpPut]
        [Route("api/users")]
        public IActionResult UpdateUser([FromBody] CreateRequestUser createRequestUser)
        {
            return Ok(userManager.UpdateUser(createRequestUser));
        }

        [HttpDelete]
        [Route("api/users/{id}")]
        public IActionResult DeleteUser([FromRoute] Guid userId)
        {
            return Ok(userManager.DeleteUser(userId));
        }
    }
}
