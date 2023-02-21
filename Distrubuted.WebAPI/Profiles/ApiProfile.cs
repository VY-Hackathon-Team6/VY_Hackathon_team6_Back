using Application.Dtos;
using AutoMapper;
using Distrubuted.WebAPI.Requests;
using Domain.Entities;

namespace Distrubuted.WebAPI.Profiles
{
    public class ApiProfile: Profile
    {
        public ApiProfile() {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<RegisterRequest, User>().ReverseMap();
            CreateMap<LoginRequest, User>().ReverseMap();
            CreateMap<string, TokenDto>().ForMember(dest => dest.AccessToken, opt => opt.MapFrom(src => src.ToString()));
        }
    }
}
