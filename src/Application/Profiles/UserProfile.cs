using Application.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles;

internal class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserEntity, User>();
        CreateMap<UserEntity, User>().ReverseMap();
    }
}
