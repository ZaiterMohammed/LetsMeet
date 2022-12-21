namespace AuthenticationAuthorizationWebApILast.Controllers
{
    using AuthenticationAuthorizationWebApILast.Models;
    using LetsMeet.WebApi.Areas.Identity.Data;
    using LetsMeet.WebApi.Data;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;


    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthenticationAuthorizationController : ControllerBase
    {
       
        private LetsMeetWebApiContext _dbContext;
        private readonly UserManager<LetsMeetWebApiUser> _userManager;
        private readonly SignInManager<LetsMeetWebApiUser> _signInManager;

        public AuthenticationAuthorizationController(LetsMeetWebApiContext dbContext,
                                                      UserManager<LetsMeetWebApiUser> userManager,
                                                      SignInManager<LetsMeetWebApiUser> signInManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] MyLoginModelType myLoginModelType)
        {
            LetsMeetWebApiUser AuthenAuthorUser = new LetsMeetWebApiUser()
            {
                Email = myLoginModelType.Email,
                UserName = myLoginModelType.Email,
                EmailConfirmed = false
            };

            var result = await _userManager.CreateAsync(AuthenAuthorUser, myLoginModelType.Password);

            if (result.Succeeded)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var Key = Encoding.ASCII.GetBytes("MY_BIG_SECRET_KEY_LKSHDJFLSDKJFW@#($)(#)34234");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, myLoginModelType.Email)
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    // SigningCridentials = new SigningCridentials(new SymmetricSecurityKey(key), new SymmetricAlgorithm());
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);
                return Ok(new { Token = tokenString, Result = "Register Success" });
            }
            else
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (var error in result.Errors)
                {
                    stringBuilder.Append(error.Description);
                }
                return Ok(new { Result = $"Register Fail:{stringBuilder.ToString()}" });
            }
        }



        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] MyLoginModelType myLoginModelType)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Email == myLoginModelType.Email);
            if (user != null)
            {
                var signInResult = await _signInManager.CheckPasswordSignInAsync(user, myLoginModelType.Password, false);
                if (signInResult.Succeeded)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var Key = Encoding.ASCII.GetBytes("MY_BIG_SECRET_KEY_LKSHDJFLSDKJFW@#($)(#)34234");
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                        new Claim(ClaimTypes.Name, myLoginModelType.Email)
                        }),
                        Expires = DateTime.UtcNow.AddDays(1),
                       // SigningCridentials = new SigningCridentials(new SymmetricSecurityKey(key), new SymmetricAlgorithm());
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var tokenString = tokenHandler.WriteToken(token);
                    return Ok(new { Token = tokenString });
                }
                else
                {
                    return Ok("Failed Signin, Try again");
                }
            }
            return Ok("Failed, Try again");
        }


        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        [HttpPost("resetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel resetPasswordModel)
        {
            var user = await _userManager.FindByEmailAsync(resetPasswordModel.Email);
            if (user == null)
                return Ok(new { Result = "ResetPassword Error" });


            var resetPassResult = await _userManager.ResetPasswordAsync(user, resetPasswordModel.Token, resetPasswordModel.Password);
            if (!resetPassResult.Succeeded)
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (var error in resetPassResult.Errors)
                {
                    stringBuilder.Append(error.Description);
                }
                return Ok(new { Result = $"ResetPassword Fail:{stringBuilder.ToString()}" });
            }

            return Ok(new { Result = "ResetPassword Success" });
        }
    }
}
