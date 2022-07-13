using System.Threading.Tasks;
using DotnetEcommerce.Api.DTOs;
using DotnetEcommerce.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DotnetEcommerce.Api.Controllers
{
    public class AccountController : BaseApiController
    {
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signinManager)
        {
            _userManager = userManager;
            _signinManager = signinManager;
        }
        
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signinManager;



        [HttpPost]
        public async Task<ActionResult<UserDto>> Login(SigninDto signinDto)
        {
            var user = await _userManager.FindByEmailAsync(signinDto.Email);
            if (user == null) return Unauthorized();

            var result = await _signinManager.CheckPasswordSignInAsync(user, signinDto.Password, false);
            if (!result.Succeeded) return Unauthorized();

            return new UserDto
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = "This will be a token"
            };
        }
    }
}
