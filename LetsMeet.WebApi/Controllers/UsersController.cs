namespace LetsMeet.WebApi.Controllers
{
    using LetsMeet.Abstractions.Managers;
    using LetsMeet.Abstractions.Models;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserManager UserManager;

        public UsersController(IUserManager userManager)
        {
            UserManager = userManager;
        }

        [HttpPost]
        [Route("api/users")]
        public IActionResult AddUser([FromBody] User user)
        {
            return Ok(UserManager.AddUser(user));
        }

        [HttpPut]
        [Route("api/users")]
        public IActionResult UpdateUser([FromBody] User user)
        {
            return Ok(UserManager.UpdateUser(user));
        }

        [HttpDelete]
        [Route("api/users/{id}")]
        public IActionResult DeleteUser([FromRoute] Guid userId)
        {
            return Ok(UserManager.DeleteUser(userId));
        }
    }
}
