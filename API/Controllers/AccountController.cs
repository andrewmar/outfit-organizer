using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Services;
using Application.DTOs;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly TokenService _tokenService;

        public AccountController(UserManager<User> userManager, TokenService tokenService)
        {
            _tokenService = tokenService;
            _userManager = userManager;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(UserLoginDto userLoginDto)
        {
            var user = await _userManager.FindByEmailAsync(userLoginDto.Email);

            if (user == null)
            {
                return Unauthorized();
            }

            var result = await _userManager.CheckPasswordAsync(user, userLoginDto.Password);

            if (result)
            {
                return CreateUserObject(user);
            }

            return Unauthorized();
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(UserRegisterDto userRegisterDto)
        {
            if (await _userManager.Users.AnyAsync(x => x.UserName == userRegisterDto.UserName))
            {
                return BadRequest("Username already taken");
            }

            var user = new User
            {
                UserName = userRegisterDto.UserName,
                Email = userRegisterDto.Email,
            };

            var result = await _userManager.CreateAsync(user, userRegisterDto.Password);

            if (result.Succeeded)
            {
                return CreateUserObject(user);
            }

            return BadRequest(result.Errors);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));

            return CreateUserObject(user);
        }

        private UserDto CreateUserObject(User user)
        {
            return new UserDto
            {
                UserName = user.UserName,
                ProfilePicture = null,
                Token = _tokenService.CreateToken(user)
            };
        }
    }
}