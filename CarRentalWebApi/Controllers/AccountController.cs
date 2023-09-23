using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Business_Layer.Services.AccountService;
using CarRentalWebApi.Models;

namespace CarRentalWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }


        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string), 401)]
        public async Task<ActionResult> Login([FromBody] LoginModel login)
        {
            var user = await _accountService.Login(login.Email, login.Password);
            if (user == null)
            {
                return Unauthorized("invalid username and password");
            }

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Email, login.Email));
            claims.Add(new Claim(ClaimTypes.Role, user.Role));
            claims.Add(new Claim(ClaimTypes.Name, user.Name));
            claims.Add(new Claim(ClaimTypes.Sid, user.Id.ToString()));
            ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(principal);
            return Ok(new { Name = user.Name, Role = user.Role,Email=user.Email,PhoneNumber=user.PhoneNumber });
        }

        
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> IsUserLoggedIn()
        {
            if (User.Identity.IsAuthenticated)
            {
                string email = User.FindFirst(ClaimTypes.Email)?.Value;
                var user = await _accountService.FindUserByEmail(email);
                return Ok(new { Name = user.Name, Role = user.Role, Email = user.Email, PhoneNumber = user.PhoneNumber });
            }
            else
            {
                return Unauthorized("Please Login in");
            }
        }
    }
}
