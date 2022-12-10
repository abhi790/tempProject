using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CovidService.Repositories;
using CovidService.Models;
using CovidService.Contracts;
namespace CovidService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserServicesController : ControllerBase
    {
        private readonly IUserServicesContract _userServiceRepository;

        public UserServicesController(IUserServicesContract userServiceRepository)
        {
            _userServiceRepository = userServiceRepository;
        }
        [HttpPost,Route("login")]
        public async Task<IActionResult> Login([FromBody] SignInModel signInModel)
        {
            var result = await _userServiceRepository.LoginAsync(signInModel);

            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }

            return Ok(result);

        }


        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] SignUpModel signUpModel)
        {
            var result = await _userServiceRepository.SignUpAsync(signUpModel);

            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }

            return Unauthorized();
        }
    }
}
