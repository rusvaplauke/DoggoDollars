using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Dtos;


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
