using Application.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles;

internal class AccountProfile : Profile
{
    public AccountProfile()
    {
        CreateMap<AccountEntity, CreateAccount>();
        CreateMap<AccountEntity, CreateAccount>().ReverseMap();

        CreateMap<AccountEntity, Account>();
        CreateMap<AccountEntity, Account>().ReverseMap();
    }
}
