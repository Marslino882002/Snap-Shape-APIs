using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Snap.Core.DTOs;
using Snap.APIs.Errors;
using Snap.Core.Entities;
using Snap.Core.Services;
using Snap.Service.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace Snap.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersIdentityController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly ICurrentUserService _currentUserService;

        public UsersIdentityController(UserManager<User>userManager ,
            SignInManager<User> signInManager , 
            ITokenService tokenService ,
            ICurrentUserService currentUserService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _currentUserService = currentUserService;

        }





        //Register
        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto model)
        {

            var user = new User()
            {
                DispalyName = model.DisplayName,
                Email = model.Email,
                UserName = model.Email.Split('@')[0]
            };

            var result = await _userManager.CreateAsync(user, model.password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description).ToArray();
                return BadRequest(new ApiValidationErrorResponse
                {
                    Erorrs = errors
                });
            }

            var ReturnedUser = new UserDto()
            {
                DispalyName = user.DispalyName,
                Email = user.Email,
                Token = await _tokenService.CreateTokenAsync(user , _userManager)
            };

            return Ok(ReturnedUser);
        }
        //login 
        [HttpPost ("Login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto model)
        {

            var User = await _userManager.FindByEmailAsync(model.Email);

            if (User is null) { return Unauthorized(new ApiResponse(401)); }  
        
    var result =   await _signInManager.CheckPasswordSignInAsync(User , model.Password , false);

            if (!result.Succeeded) { return Unauthorized(new ApiResponse(401)); }
            return Ok(
          new UserDto() {
              DispalyName = User.DispalyName,
              Email = User.Email,
              Token = await _tokenService.CreateTokenAsync(User, _userManager)
          }
                
                
            );

        }

        [HttpGet("profile")]

        public async Task<ActionResult<UserDto>> GetCurrentUserProfile()
        {
            try
            {
                var user = await _currentUserService.GetUserAsync();  // Get the full user object

                // Map User to UserDto if necessary
                var userDto = new UserDto()
                {
                    DispalyName = user.DispalyName,
                    Email = user.Email,
                    Token = await _tokenService.CreateTokenAsync(user, _userManager)
                };

                return Ok(userDto);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("User is not authorized or not logged in.");
            }
        }



        [HttpGet("current-user-id")]
        [Authorize]
        public ActionResult<int> GetCurrentUserId()
        {
            try
            {
                var userId = _currentUserService.GetUserId();  // Get the current user's ID
                return Ok(userId);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("User is not authorized or not logged in.");
            }
        }

    }
}
