using Application.Services.Contracts;
using AutoMapper;
using Domain.Entities;
using Infrastucture.DataModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly UserManager<UserDataModel> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public UserService(UserManager<UserDataModel> userManager, IConfiguration configuration, IMapper mapper)
        {
            _userManager = userManager;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var userDataModel = await _userManager.Users.ToListAsync();
            return _mapper.Map<IEnumerable<UserDataModel>, IEnumerable<User>>(userDataModel);
        }

        public async Task<string> Login(User user)
        {
            var userToLogin = _mapper.Map<UserDataModel>(await _userManager.FindByEmailAsync(user.Email));

            if (userToLogin is null)
            {
                throw new Exception("User is null.");
            }

            var roles = await _userManager.GetRolesAsync(userToLogin);

            // Generamos un token segun los claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Sid, userToLogin.Id),
                new Claim(ClaimTypes.Email, userToLogin.Email),
                new Claim(ClaimTypes.GivenName, userToLogin.Name)
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: credentials);

            var jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

            return jwt;
        }

        public async Task<User> Register(User user)
        {
            var userDataModel = _mapper.Map<UserDataModel>(user);
            userDataModel.UserName = user.Email;

            var result = await _userManager.CreateAsync(userDataModel, "h0lA#12341");

            if (!result.Succeeded)
                throw new Exception(result.Errors.FirstOrDefault().ToString());

            await _userManager.AddToRoleAsync(userDataModel, "Viewer");

            return _mapper.Map<User>(userDataModel);
        }
    }
}
