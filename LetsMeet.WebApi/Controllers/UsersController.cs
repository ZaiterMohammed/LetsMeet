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
        public IActionResult AddUser([FromBody] User user)
        {
            return Ok(userManager.AddUser(user));
        }

        [HttpPut]
        [Route("api/users")]
        public IActionResult UpdateUser([FromBody] User user)
        {
            return Ok(userManager.UpdateUser(user));
        }

        [HttpDelete]
        [Route("api/users/{userId}")]
        public IActionResult DeleteUser([FromRoute] Guid userId)
        {
            return Ok(userManager.DeleteUser(userId));
        }
    }
}
