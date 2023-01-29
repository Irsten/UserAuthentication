using Microsoft.AspNetCore.Mvc;
using UserAuthentication.Models;
using UserAuthentication.Services;

namespace UserAuthentication.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }


        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody] RegisterUserDto dto)
        {
            _accountService.RegisterUser(dto);
            return Created("https://localhost:7162", "Account created successfully");
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginDto dto)
        {
            string token = _accountService.GenerateJwt(dto);
            return Created("https://localhost:7162", token);
        }
    }
}
