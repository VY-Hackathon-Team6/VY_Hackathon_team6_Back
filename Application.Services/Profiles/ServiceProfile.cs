using AutoMapper;
using Domain.Entities;
using Infrastucture.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Profiles
{
    public class ServiceProfile: Profile
    {
        public ServiceProfile() {
            CreateMap<User, UserDataModel>().ReverseMap();
            CreateMap<string, OutputGroundHandling>().ReverseMap();
        }
    }
}
