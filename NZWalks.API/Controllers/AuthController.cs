using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Model.DTO.LoginDTO;
using NZWalks.API.Model.DTO.RegisterDTO;
using NZWalks.API.Repositories.Interfaces;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenRepository _tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            _userManager = userManager;
            _tokenRepository = tokenRepository;
        }
        // POST: /api/Auth/Register
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequist_Dto registerRequist_Dto)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequist_Dto.Username,
                Email = registerRequist_Dto.Username
            };

            var identityResult = await _userManager.CreateAsync(identityUser, registerRequist_Dto.Password);

            if(identityResult.Succeeded)
            {
                // Add roles to this User.

                if(registerRequist_Dto.Roles != null && registerRequist_Dto.Roles.Any())
                {
              identityResult =  await _userManager.AddToRolesAsync(identityUser, registerRequist_Dto.Roles);

                    if(identityResult.Succeeded)
                    {
                        return Ok("User registered! Please Login");
                    }
                }

            }

            return BadRequest("Something went wrong!");
        }


        // Post: /api/Auth/Login

        [HttpPost]
        [Route("Login")]

        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {

           var user = await _userManager.FindByEmailAsync(loginRequestDto.Username);

            if(user != null)
            {
              var checkPasswordResult =  await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

                if(checkPasswordResult)
                {
                    // Get roles for this user.
                    var roles = await _userManager.GetRolesAsync(user);

                    if(roles != null)
                    {

                        // Create Token

                       var jwtToken =  _tokenRepository.CreateJWTToken(user, roles.ToList());

                        var response = new LoginResponseDto
                        {
                            JwtToken = jwtToken,
                        };

                        return Ok(response);

                    }

                    //return Ok("Login Successful"); 
                }
            }

            return BadRequest("Username or password is invalid!");
        }
    }
}
