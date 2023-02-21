using Application.Dtos;
using Application.Services.Contracts;
using AutoMapper;
using CrossCutting.Utils;
using Distrubuted.WebAPI.Requests;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Distrubuted.WebAPI.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [ApiVersion("1.0")]

    public class UserController: ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper) 
        {
            _userService = userService; 
            _mapper = mapper;
        }

        [Microsoft.AspNetCore.Mvc.Route("login")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginRequest login)
        {
            var user = _mapper.Map<User>(login);
            var tokenString = await _userService.Login(user);
            var token = _mapper.Map<TokenDto>(tokenString);
            return Ok(token);
        }

        [HttpGet]
        [AllowAnonymous]

        public async Task<IActionResult> GetAll()
        {
            var userDto = await _userService.GetUsers();
            var users = _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(userDto);

            return Ok(users);
        }


    }
}
