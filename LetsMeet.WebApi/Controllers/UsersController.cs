namespace LetsMeet.WebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using LetsMeet.Abstractions;
    using LetsMeet.Abstractions.Models;
    using LetsMeet.Business

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
        public IActionResult DeleteUser([FromRoute] Guid id)
        {
            return Ok(UserManager.DeleteUser(id));
        }
    }
}
