using Application.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles;

internal class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserEntity, User>();
        CreateMap<UserEntity, User>().ReverseMap();
    }
}
